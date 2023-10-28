using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.Menu.Domain.Model.MenuItems;
using Restaurant.Menu.Domain.Repositories;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.Repositories
{
    internal class MenuItemRepository : IMenuItemRepository
    {
        private readonly DomainDbContext _dbContext;

        public MenuItemRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(MenuItem obj)
        {
            await _dbContext.MenuItem.AddAsync(obj);
        }

        public Task Delete(MenuItem menuItem)
        {
            _dbContext.MenuItem.Remove(menuItem);

            return Task.CompletedTask;
        }

        public async Task<MenuItem?> FindByIdAsync(Guid id)
        {
            return await _dbContext.MenuItem.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(MenuItem menuItem)
        {
            _dbContext.MenuItem.Update(menuItem);

            return Task.CompletedTask;
        }
    }
}
