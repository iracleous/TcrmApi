using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using System.Linq;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
         ApiResult< IQueryable<Customer>> Search(
            SearchCustomerOptions options);

         ApiResult< Customer> Create(CreateCustomerOptions options);
         ApiResult<Customer> GetCustomerById(int customerId);

         ApiResult< List<Customer>> GetCustomers(int howMany);

        ApiResult<Customer> Update(int id, CreateCustomerOptions options);

    }
}
