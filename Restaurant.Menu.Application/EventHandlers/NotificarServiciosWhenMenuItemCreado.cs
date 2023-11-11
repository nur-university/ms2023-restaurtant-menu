using MediatR;
using Restaurant.Menu.Application.Services;
using Restaurant.Menu.Domain.Model.MenuItems.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.EventHandlers
{
    internal class NotificarServiciosWhenMenuItemCreado : INotificationHandler<MenuItemCreado>
    {

        private readonly IOutboxService _outboxService;

        public NotificarServiciosWhenMenuItemCreado(IOutboxService outboxService)
        {
            _outboxService = outboxService;
        }

        public Task Handle(MenuItemCreado notification, CancellationToken cancellationToken)
        {
            return _outboxService.Add(notification);
        }
    }
}
