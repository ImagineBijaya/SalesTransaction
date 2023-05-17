using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SalesTransactionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesTransactionApi.Repositories
{
    public class Productservice : IProductService
    {
        private readonly SalesContext _dbContext;

        public Productservice(SalesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@name", product.ProductName));
            parameter.Add(new SqlParameter("@unit", product.ProductUnit));
            parameter.Add(new SqlParameter("@price", product.ProductPrice));
            parameter.Add(new SqlParameter("@statementType",  "Insert"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_ProductOperation @id, @name, @unit, @price, @statementType", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteProductAsync(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@name",DBNull.Value));
            parameter.Add(new SqlParameter("@unit", DBNull.Value));
            parameter.Add(new SqlParameter("@price", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Delete"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_ProductOperation @id, @name, @unit, @price, @statementType", parameter.ToArray()));

            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
             var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@name",DBNull.Value));
            parameter.Add(new SqlParameter("@unit", DBNull.Value));
            parameter.Add(new SqlParameter("@price", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));

            var result = await Task.Run(() => _dbContext.Product
           .FromSqlRaw(@"exec sp_ProductOperation @id, @name, @unit, @price, @statementType", parameter.ToArray()).ToListAsync());

            return result;
        }

        public  async Task<List<Product>> GetProductListAsync()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@name", DBNull.Value));
            parameter.Add(new SqlParameter("@unit", DBNull.Value));
            parameter.Add(new SqlParameter("@price", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));
            return await _dbContext.Product
                 .FromSqlRaw(@"exec sp_ProductOperation @id, @name, @unit, @price, @statementType", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", product.ProductId));
            parameter.Add(new SqlParameter("@name", product.ProductName));
            parameter.Add(new SqlParameter("@unit", product.ProductUnit));
            parameter.Add(new SqlParameter("@price", product.ProductPrice));
            parameter.Add(new SqlParameter("@statementType", "Update"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_ProductOperation @id, @name, @unit, @price, @statementType", parameter.ToArray()));

            return result;
        }
    }
}
