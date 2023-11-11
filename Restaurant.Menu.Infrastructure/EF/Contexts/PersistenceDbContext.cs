using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Infrastructure.EF.PersistenceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.Contexts
{
    internal class PersistenceDbContext : DbContext
    {
        public virtual DbSet<MenuItemPersistenceModel> MenuItem { set; get; }
        public virtual DbSet<CategoriaMenuPersistenceModel> Categoria { get; set; }
        public virtual DbSet<OutboxPersistenceModel> Outbox { get; set; }

        public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options)
        {
        }
    }
}
