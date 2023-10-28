using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Application.Dto;
using Restaurant.Menu.Application.UseCases.MenuItems.GetMenuItemById;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.UseCases.MenuItems
{
    internal class GetMenuItemByIdHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItemDto>
    {
        private readonly PersistenceDbContext _dbContext;

        public GetMenuItemByIdHandler(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MenuItemDto?> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.MenuItem
                .Include(x =>  x.CategoriaMenu)
                .AsNoTracking()
                .Where(x => x.Id == request.MenuItemId)
                .Select(x => new MenuItemDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    NombreCategoria = x.CategoriaMenu.Nombre,
                    CategoriaId = x.CategoriaMenuId
                })
                .FirstOrDefaultAsync();
        }
    }
}
