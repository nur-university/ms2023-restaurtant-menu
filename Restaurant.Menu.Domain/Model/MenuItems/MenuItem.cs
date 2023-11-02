using Restaurant.Menu.Domain.Model.MenuItems.Events;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Model.MenuItems
{
    public class MenuItem : AggregateRoot
    {
        public string Nombre { get; private set; }
        public TipoItem Tipo { get; private set; }

        public string Descripcion { get; private set; }

        public PrecioValue Precio { get; private set; }

        public bool Activo { get; private set; }

        public Guid CategoriaMenuId { get; private set; }

        internal MenuItem(Guid categoriaMenuId, string nombre, TipoItem tipo, string descripcion, decimal precio)
        {
            Id = Guid.NewGuid();
            CheckRule(new StringNotNullOrEmptyRule(nombre));
            if (categoriaMenuId == Guid.Empty)
                throw new BussinessRuleValidationException("La categoria no puede ser vacia");
            CategoriaMenuId = categoriaMenuId;
            Nombre = nombre;
            Tipo = tipo;
            Descripcion = descripcion;
            Precio = precio;
            Activo = true;
        }

        public void Editar(string nombre, string descripcion, decimal precio, bool activo)
        {
            CheckRule(new StringNotNullOrEmptyRule(nombre));
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Activo = activo;
        }

        public static MenuItem Create(Guid categoriaMenuId, string nombre, TipoItem tipo, string descripcion, decimal precio)
        {
            var obj = new MenuItem(categoriaMenuId, nombre, tipo, descripcion, precio);
            obj.AddDomainEvent(new MenuItemCreado(
                    obj.Id,
                    obj.Nombre,
                    obj.Tipo == TipoItem.Receta,
                    obj.Tipo == TipoItem.Inventariable
                ));
            return obj;
        }

        private MenuItem() { }
    }
}
