using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Shared.Utilities.Result.Abstract;
using Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<Customer>> Get(string customerId)
        {
            var customer = await _unitOfWork.Customers.GetAsync(c=>c.CustomerId == customerId);
            if (customer != null)
            {
                return new SuccessDataResult<Customer>(customer, "İlgili müşteri bulundu.");
            }
            return new ErrorDataResult<Customer>("Müşteri bulunamadı..");
        }

        public async Task<IDataResult<IList<Customer>>> GetAll()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            if (customers.Any())
            {
                return new SuccessDataResult<IList<Customer>>(customers, "Tüm müşteriler listelendi.");
            }
            return new ErrorDataResult<IList<Customer>>("Müşteri listesi boş..");
        }

        public async Task<IDataResult<IList<Customer>>> GetAllByCountry(string country)
        {
            var customers = await _unitOfWork.Customers.GetAllAsync(c=>c.Country == country);
            if (customers.Any())
            {
                return new SuccessDataResult<IList<Customer>>(customers, "İlgili şehirdeki müşteriler listelendi.");
            }
            return new ErrorDataResult<IList<Customer>>("İlgili şehirde müşteri bulunamadı..");
        }
    }
}
