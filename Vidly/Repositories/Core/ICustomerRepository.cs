using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Repositories.Core
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<CustomerDto> GetCustomersWithQuery(string query = null);
        CustomerDto GetCustomerWithId(int id);
        int CreateCustomer(CustomerDto customerDto);
        void UpdateCustomer(int id, CustomerDto customerDto);
        void DeleteCustomer(int id);

    }

}