using MediatR;
using Restaurant.Menu.Domain.Model.MenuItems;
using Restaurant.Menu.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.MenuItems.CrearMenuItem
{
    internal class CrearMenuItemHandler : IRequestHandler<CrearMenuItemCommand, Guid>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearMenuItemHandler(IMenuItemRepository menuItemRepository, IUnitOfWork unitOfWork)
        {
            _menuItemRepository = menuItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearMenuItemCommand request, CancellationToken cancellationToken)
        {
            TipoItem tipo = request.TipoItem == CrearMenuItemCommand.TipoMenuItem.Receta ? TipoItem.Receta : TipoItem.Inventariable;
            var menuItem = new MenuItem(request.CategoriaId, request.Nombre, tipo, request.Descripcion, request.Precio);
            await _menuItemRepository.CreateAsync(menuItem);
            await _unitOfWork.Commit();
            return menuItem.Id;
        }
    }
}
