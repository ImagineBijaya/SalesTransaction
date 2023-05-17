using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesTransactionApi.Models;

namespace SalesTransactionApi.Repositories
{
   public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomerListAsync();
        public Task<IEnumerable<Customer>> GetCustomerByIdAsync(int Id);
        public Task<int> AddCustomerAsync(Customer customer);
        public Task<int> UpdateCustomerAsync(Customer customer);
        public Task<int> DeleteCustomerAsync(int Id);
    }
}
