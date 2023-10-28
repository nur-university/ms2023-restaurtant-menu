using MediatR;
using Restaurant.Menu.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.MenuItems.GetMenuItemById
{
    public class GetMenuItemByIdQuery : IRequest<MenuItemDto>
    {
        public Guid MenuItemId { get; set; }

        public GetMenuItemByIdQuery(Guid menuItemId)
        {
            MenuItemId = menuItemId;
        }
    }
}
