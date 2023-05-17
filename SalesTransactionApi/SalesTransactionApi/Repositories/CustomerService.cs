using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesTransactionApi.Models;

namespace SalesTransactionApi.Repositories
{
    public class CustomerService : ICustomerService
    {
        private readonly SalesContext _dbContext;

        public CustomerService(SalesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@name", customer.CustomerName));
            parameter.Add(new SqlParameter("@address", customer.CustomerAddress));
            parameter.Add(new SqlParameter("@phone", customer.PhoneNumber));
            parameter.Add(new SqlParameter("@statementType", "Insert"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_CustomerOperation @id, @name, @address, @phone, @statementType", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteCustomerAsync(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@name",DBNull.Value));
            parameter.Add(new SqlParameter("@address", DBNull.Value));
            parameter.Add(new SqlParameter("@phone", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Delete"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_CustomerOperation @id, @name, @address, @phone, @statementType", parameter.ToArray()));

            return result;
        }

        public  async Task<IEnumerable<Customer>> GetCustomerByIdAsync(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@name", DBNull.Value));
            parameter.Add(new SqlParameter("@address", DBNull.Value));
            parameter.Add(new SqlParameter("@phone", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));

            var result = await Task.Run(() => _dbContext.Customer
           .FromSqlRaw(@"exec sp_CustomerOperation @id, @name, @address, @phone, @statementType", parameter.ToArray()).ToListAsync());

            return result;
        }

        public  async Task<List<Customer>> GetCustomerListAsync()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@name", DBNull.Value));
            parameter.Add(new SqlParameter("@address", DBNull.Value));
            parameter.Add(new SqlParameter("@phone", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));

            var result = await Task.Run(() => _dbContext.Customer
           .FromSqlRaw(@"exec sp_CustomerOperation @id, @name, @address, @phone, @statementType", parameter.ToArray()).ToListAsync());

            return result;
        }

        public  async Task<int> UpdateCustomerAsync(Customer customer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", customer.CustomerId));
            parameter.Add(new SqlParameter("@name", customer.CustomerName));
            parameter.Add(new SqlParameter("@address",customer.CustomerAddress));
            parameter.Add(new SqlParameter("@phone", customer.PhoneNumber));
            parameter.Add(new SqlParameter("@statementType", "Update"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_CustomerOperation @id, @name, @address, @phone, @statementType", parameter.ToArray()));

            return result;
        }
    }
}
