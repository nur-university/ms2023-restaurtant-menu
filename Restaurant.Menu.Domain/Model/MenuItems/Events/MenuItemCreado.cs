using MediatR;
using Restaurant.SharedKernel.Core;

namespace Restaurant.Menu.Domain.Model.MenuItems.Events;

public record MenuItemCreado : DomainEvent, INotification
{
    public Guid MenuItemId { get; init; }

    public string Nombre { get; set; }
    public bool EsReceta { get; set; }
    public bool EsInventariable { get; set; }

    public MenuItemCreado(Guid menuItemId,
        string nombre, 
        bool esReceta, 
        bool esInventariable) : base(DateTime.Now)
    {
        MenuItemId = menuItemId;
        Nombre = nombre;
        EsReceta = esReceta;
        EsInventariable = esInventariable;
    }
}
