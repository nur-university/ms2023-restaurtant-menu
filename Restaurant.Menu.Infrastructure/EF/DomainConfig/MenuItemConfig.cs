using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.Menu.Domain.Model.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.DomainConfig
{
    internal class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("menuItem");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("menuItemId");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre");

            builder.Property(x => x.Activo)
                .HasColumnName("activo");

            builder.Property(x => x.CategoriaMenuId)
                .HasColumnName("categoriaMenuId");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                v => v.Value,
                v => new PrecioValue(v)
            );

            builder.Property(x => x.Precio)
                .HasConversion(precioConverter)
                .HasColumnName("precio");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
