﻿using Anshan.Framework.Core;
using Anshan.Framework.Core.Events;
using Anshan.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace Anshan.Framework.EF
{
    public class EfUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IEventPublisher _eventPublisher;

        public EfUnitOfWork(TContext context, IEventPublisher eventPublisher)
        {
            this._context = context;
            _eventPublisher = eventPublisher;
        }

        public void Begin()
        {
            _context.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            var entity = _context.ChangeTracker.Entries().FirstOrDefault(x => (x.State == EntityState.Added));

            await _context.SaveChangesAsync();

            PublishAggregateId(entity);

            _context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        private void PublishAggregateId(EntityEntry entityEntry)
        {
            if (entityEntry is null) return;

            switch (entityEntry.Entity)
            {
                case AggregateRoot<int> aggregateRoot:
                    _eventPublisher.Publish(new EntityCreated(aggregateRoot.Id));
                    break;

                case Entity<int> entity:
                    _eventPublisher.Publish(new EntityCreated(entity.Id));
                    break;
            }
        }
    }
}