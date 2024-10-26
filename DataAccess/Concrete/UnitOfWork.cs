using DataAccess.Abstract;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _context;
        private ICustomerDal _customerDal;

        public UnitOfWork(CustomerContext context)
        {
            _context = context;
        }

        public ICustomerDal Customers => _customerDal ?? new EfCustomerDal(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
