using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.Services
{
    public interface IBusService
    {
        Task PublishAsync(object message);
    }
}
