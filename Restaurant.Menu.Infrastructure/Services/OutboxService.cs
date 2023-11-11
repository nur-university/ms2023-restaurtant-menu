using Microsoft.EntityFrameworkCore;
using Restaurant.Menu.Application.OutBox;
using Restaurant.Menu.Application.Services;
using Restaurant.Menu.Infrastructure.EF.Contexts;
using Restaurant.Menu.Infrastructure.EF.PersistenceModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.Services
{
    internal class OutboxService : IOutboxService
    {
        private readonly DomainDbContext _dbContext;

        public OutboxService(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(DomainEvent content)
        {
            var outboxMessage = new OutboxMessage<DomainEvent>(content);

            await _dbContext.OutboxMessage.AddAsync(outboxMessage);
        }

        public async Task<ICollection<OutboxMessage<DomainEvent>>> GetUnprocessedMessages(int pageSize = 20)
        {
            return await _dbContext.OutboxMessage
                .Where(x => !x.Processed)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
