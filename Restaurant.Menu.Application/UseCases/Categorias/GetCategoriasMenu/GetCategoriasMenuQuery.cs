using MediatR;
using Restaurant.Menu.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.UseCases.Categorias.GetCategoriasMenu
{
    public class GetCategoriasMenuQuery : IRequest<ICollection<CategoriaDto>>
    {
        
    }
}
