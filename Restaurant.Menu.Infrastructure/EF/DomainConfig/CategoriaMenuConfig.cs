using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Menu.Domain.Model.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.DomainConfig
{
    internal class CategoriaMenuConfig : IEntityTypeConfiguration<CategoriaMenu>
    {
        public void Configure(EntityTypeBuilder<CategoriaMenu> builder)
        {
            builder.ToTable("categoriaMenu");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("categoriaMenuItemId");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre");

            builder.Property(x => x.Activa)
                .HasColumnName("activa");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);

        }
    }
}
