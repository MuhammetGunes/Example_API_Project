using Entities.Concrete;
using Shared.Utilities.Result;
using Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<IList<Customer>>> GetAll();
        Task<IDataResult<IList<Customer>>> GetAllByCountry(string country);
        Task<ResponseModel<Customer>> Get(string customerId);

    }
}
