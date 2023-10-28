using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.Menu.Domain.Model.MenuItems;
using Restaurant.Menu.Infrastructure.EF.DomainConfig;
using Restaurant.Menu.Infrastructure.EF.PersistenceModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.Contexts
{
    internal class DomainDbContext : DbContext
    {
        public virtual DbSet<MenuItem> MenuItem { set; get; }
        public virtual DbSet<CategoriaMenu> Categoria { get; set; }
        
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CategoriaMenuConfig());
            modelBuilder.ApplyConfiguration(new MenuItemConfig());

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
