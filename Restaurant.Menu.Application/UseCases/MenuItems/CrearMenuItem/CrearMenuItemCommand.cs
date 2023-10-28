using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.MenuItems.CrearMenuItem
{
    public class CrearMenuItemCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Guid CategoriaId { get; set; }
        public TipoMenuItem TipoItem { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }

        public enum TipoMenuItem{
            Receta = 1,
            Inventariable = 2
        }
    }
}
