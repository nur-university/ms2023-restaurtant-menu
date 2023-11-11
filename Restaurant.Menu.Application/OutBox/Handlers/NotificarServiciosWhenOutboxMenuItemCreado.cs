using MediatR;
using Restaurant.Menu.Application.Services;
using Restaurant.Menu.Domain.Model.MenuItems.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.OutBox.Handlers
{
    internal class NotificarServiciosWhenOutboxMenuItemCreado : INotificationHandler<OutboxMessage<MenuItemCreado>>
    {
        private readonly IBusService _busService;

        public NotificarServiciosWhenOutboxMenuItemCreado(IBusService busService)
        {
            _busService = busService;
        }

        public async Task Handle(OutboxMessage<MenuItemCreado> notification, CancellationToken cancellationToken)
        {
            MenuItemCreado evento = notification.Content;
            IntegrationEvents.MenuItemCreado integrationEvent = new IntegrationEvents.MenuItemCreado()
            {
                MenuItemId = evento.MenuItemId,
                Nombre = evento.Nombre,
                EsInventariable = evento.EsInventariable,
                EsReceta = evento.EsReceta
            };

            await _busService.PublishAsync(integrationEvent);
        }
    }
}
