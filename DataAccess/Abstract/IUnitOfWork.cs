﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICustomerDal Customers { get; }
        Task<int> SaveAsync();
    }
}
