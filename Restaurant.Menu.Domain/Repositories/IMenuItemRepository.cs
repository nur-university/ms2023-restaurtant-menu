using Restaurant.Menu.Domain.Model.MenuItems;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Repositories
{
    public interface IMenuItemRepository : IRepository<MenuItem, Guid>
    {
        Task Update(MenuItem menuItem);
        Task Delete(MenuItem menuItem);
    }
}
