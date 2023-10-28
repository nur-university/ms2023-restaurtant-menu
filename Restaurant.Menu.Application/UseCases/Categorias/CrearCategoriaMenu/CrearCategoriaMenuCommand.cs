using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.Categorias.CrearCategoriaMenu
{
    public class CrearCategoriaMenuCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
    }
}
