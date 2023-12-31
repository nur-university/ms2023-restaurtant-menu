﻿using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Restaurant.Menu.Application;
using Restaurant.Menu.Application.Services;
using Restaurant.Menu.Domain.Repositories;
using Restaurant.Menu.Infrastructure.BackgroundJobs;
using Restaurant.Menu.Infrastructure.EF;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using Restaurant.Menu.Infrastructure.EF.Repositories;
using Restaurant.Menu.Infrastructure.MassTransit;
using Restaurant.Menu.Infrastructure.Security;
using Restaurant.Menu.Infrastructure.Services;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure
{
    public static  class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IOutboxService, OutboxService>();
            
            AddDatabase(services, configuration, isDevelopment);

            AddAuthentication(services, configuration);

            AddMassTransitWithRabbitMq(services, configuration);

            AddQuartz(services);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("MenuDbConnectionString");
            services.AddDbContext<PersistenceDbContext>(context =>
                    context.UseSqlServer(connectionString));
            services.AddDbContext<DomainDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoriaMenuRepository, CategoriaMenuRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<PersistenceDbContext>();
                context.Database.Migrate();
            }
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jwtoptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = jwtoptions.ValidateIssuer,
                    ValidateAudience = jwtoptions.ValidateAudience,
                    ValidIssuer = jwtoptions.ValidIssuer,
                    ValidAudience = jwtoptions.ValidAudience
                };
            });
        }

        private static IServiceCollection AddMassTransitWithRabbitMq(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBusService, MassTransitBusService>();

            var serviceName = configuration.GetValue<string>("ServiceName");
            var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

            services.AddMassTransit(configure =>
            {
               
                configure.UsingRabbitMq((context, configurator) =>
                {

                    configurator.Host(rabbitMQSettings.Host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceName, false));
                    configurator.UseMessageRetry(retryConfigurator =>
                    {
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                    });
                });
            });

            return services;
        }

        public static IServiceCollection AddQuartz(IServiceCollection services)
        {
            services.AddQuartz(configure =>
            {
                var jobKey = new JobKey(nameof(OutboxProcessor));

                configure
                    .AddJob<OutboxProcessor>(jobKey)
                    .AddTrigger(trigger =>
                    {
                        trigger.ForJob(jobKey)
                            .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(10).RepeatForever());
                    });

                configure.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService();

            return services;
        }
    }
}
