using Restaurant.Menu.Domain.Model.Categoria;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Repositories
{
    public interface ICategoriaMenuRepository : IRepository<CategoriaMenu, Guid>
    {
        Task Update(CategoriaMenu categoriaMenu);
        Task Delete(CategoriaMenu categoriaMenu);
    }
}
