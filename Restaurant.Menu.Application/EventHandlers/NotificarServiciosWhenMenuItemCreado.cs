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

        private readonly IBusService _bus;

        public NotificarServiciosWhenMenuItemCreado(IBusService bus)
        {
            _bus = bus;
        }

        public async Task Handle(MenuItemCreado notification, CancellationToken cancellationToken)
        {
            IntegrationEvents.MenuItemCreado evento = new IntegrationEvents.MenuItemCreado()
            {
                MenuItemId = notification.MenuItemId,
                Nombre = notification.Nombre,
                EsReceta = notification.EsReceta,
                EsInventariable = notification.EsInventariable
            };

            await _bus.PublishAsync(evento);
        }
    }
}
