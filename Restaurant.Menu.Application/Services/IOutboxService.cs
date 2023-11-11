using Restaurant.Menu.Application.OutBox;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Application.Services
{
    public interface IOutboxService
    {
        Task Add(DomainEvent content);

        //Task Update(OutboxMessage<DomainEvent> message);

        Task<ICollection<OutboxMessage<DomainEvent>>> GetUnprocessedMessages(int pageSize = 20);
    }
}
