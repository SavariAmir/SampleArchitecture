using Anshan.Framework.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Anshan.Framework.EF
{
    public class FakeEfUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;

        public FakeEfUnitOfWork(TContext context)
        {
            this._context = context;
        }

        public void Begin()
        {
        }

        public Task Commit()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }
    }
}