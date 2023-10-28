using MediatR;
using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.Menu.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.Categorias.CrearCategoriaMenu
{
    internal class CrearCategoriaMenuHandler : IRequestHandler<CrearCategoriaMenuCommand, Guid>
    {
        private readonly ICategoriaMenuRepository _categoriaMenuRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCategoriaMenuHandler(ICategoriaMenuRepository categoriaMenuRepository, IUnitOfWork unitOfWork)
        {
            _categoriaMenuRepository = categoriaMenuRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCategoriaMenuCommand request, CancellationToken cancellationToken)
        {

            var categoriaMenu = new CategoriaMenu(request.Nombre);

            await _categoriaMenuRepository.CreateAsync(categoriaMenu);

            await _unitOfWork.Commit();

            return categoriaMenu.Id;
        }
    }
}
