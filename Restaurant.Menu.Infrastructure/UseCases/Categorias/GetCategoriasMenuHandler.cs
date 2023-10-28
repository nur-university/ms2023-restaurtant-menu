using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Application.Dto;
using Restaurant.Menu.Application.UseCases.Categorias.GetCategoriasMenu;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.UseCases.Categorias
{
    internal class GetCategoriasMenuHandler : IRequestHandler<GetCategoriasMenuQuery, ICollection<CategoriaDto>>
    {
        private readonly PersistenceDbContext _dbContext;

        public GetCategoriasMenuHandler(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<CategoriaDto>> Handle(GetCategoriasMenuQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categoria.AsNoTracking().Select(cat => new CategoriaDto
            {
                Id = cat.Id,
                Nombre = cat.Nombre,
                Activa = cat.Activa
            }).ToListAsync(cancellationToken);
        }
    }
}
