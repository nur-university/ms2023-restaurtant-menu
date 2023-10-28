using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.Menu.Domain.Repositories;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Menu.Infrastructure.EF.Repositories
{
    internal class CategoriaMenuRepository : ICategoriaMenuRepository
    {
        private readonly DomainDbContext _dbContext;

        public CategoriaMenuRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CategoriaMenu obj)
        {
            await _dbContext.Categoria.AddAsync(obj);
        }

        public Task Delete(CategoriaMenu categoriaMenu)
        {
            _dbContext.Categoria.Remove(categoriaMenu);

            return Task.CompletedTask;
        }

        public async Task<CategoriaMenu?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Categoria.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(CategoriaMenu categoriaMenu)
        {
            _dbContext.Categoria.Update(categoriaMenu);

            return Task.CompletedTask;
        }
    }
}
