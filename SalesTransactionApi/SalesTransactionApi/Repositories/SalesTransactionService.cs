using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesTransactionApi.Models;

namespace SalesTransactionApi.Repositories
{
    public class SalesTransactionService : ISalesTransactionService
    {
        private readonly SalesContext _dbContext;

        public SalesTransactionService(SalesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddSalesTransactionAsync(SalesTransaction salesTransaction)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@customerId", salesTransaction.CustomerId));
            parameter.Add(new SqlParameter("@productId", salesTransaction.ProductId));
            parameter.Add(new SqlParameter("@quantity", salesTransaction.Quantity));
            parameter.Add(new SqlParameter("@amount", salesTransaction.Amount));
            parameter.Add(new SqlParameter("@invoice", salesTransaction.Invoice));
            parameter.Add(new SqlParameter("@transactionDate", salesTransaction.TransactionDate));
            parameter.Add(new SqlParameter("@statementType", "Insert"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_SalesTransactionOperation @id, @customerId, @productId, @quantity,@amount,@invoice, @transactionDate, @statementType", parameter.ToArray()));

            return result;
        }

        public  async Task<int> DeleteSalesTransactionAsync(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@customerId", DBNull.Value));
            parameter.Add(new SqlParameter("@productId", DBNull.Value));
            parameter.Add(new SqlParameter("@quantity", DBNull.Value));
            parameter.Add(new SqlParameter("@amount", DBNull.Value));
            parameter.Add(new SqlParameter("@invoice", DBNull.Value));
            parameter.Add(new SqlParameter("@transactionDate", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Delete"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_SalesTransactionOperation @id, @customerId, @productId, @quantity,@amount,@invoice, @transactionDate, @statementType", parameter.ToArray()));

            return result;
        }

        public  async Task<IEnumerable<SalesTransaction>> GetSalesTransactionByIdAsync(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", Id));
            parameter.Add(new SqlParameter("@customerId", DBNull.Value));
            parameter.Add(new SqlParameter("@productId", DBNull.Value));
            parameter.Add(new SqlParameter("@quantity", DBNull.Value));
            parameter.Add(new SqlParameter("@amount", DBNull.Value));
            parameter.Add(new SqlParameter("@invoice", DBNull.Value));
            parameter.Add(new SqlParameter("@transactionDate", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));

            var result = await Task.Run(() => _dbContext.SalesTransaction
           .FromSqlRaw(@"exec sp_SalesTransactionOperation @id, @customerId, @productId, @quantity,@amount,@invoice, @transactionDate, @statementType", parameter.ToArray()).ToListAsync());

            return result;
        }

        public async Task<List<SalesTransaction>> GetSalesTransactionListAsync()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", DBNull.Value));
            parameter.Add(new SqlParameter("@customerId", DBNull.Value));
            parameter.Add(new SqlParameter("@productId", DBNull.Value));
            parameter.Add(new SqlParameter("@quantity", DBNull.Value));
            parameter.Add(new SqlParameter("@amount", DBNull.Value));
            parameter.Add(new SqlParameter("@invoice", DBNull.Value));
            parameter.Add(new SqlParameter("@transactionDate", DBNull.Value));
            parameter.Add(new SqlParameter("@statementType", "Select"));

            var result = await Task.Run(() => _dbContext.SalesTransaction
           .FromSqlRaw(@"exec sp_SalesTransactionOperation @id, @customerId, @productId, @quantity,@amount,@invoice, @transactionDate, @statementType", parameter.ToArray()).ToListAsync());

            return result;
        }

        public async Task<int> UpdateSalesTransactionAsync(SalesTransaction salesTransaction)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", salesTransaction.SalesTransactionId));
            parameter.Add(new SqlParameter("@customerId", salesTransaction.CustomerId));
            parameter.Add(new SqlParameter("@productId", salesTransaction.ProductId));
            parameter.Add(new SqlParameter("@quantity", salesTransaction.Quantity));
            parameter.Add(new SqlParameter("@amount", salesTransaction.Amount));
            parameter.Add(new SqlParameter("@invoice", salesTransaction.Invoice));
            parameter.Add(new SqlParameter("@transactionDate", salesTransaction.TransactionDate));
            parameter.Add(new SqlParameter("@statementType", "Update"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec sp_SalesTransactionOperation @id, @customerId, @productId, @quantity,@amount,@invoice, @transactionDate, @statementType", parameter.ToArray()));

            return result;
        }
    }
}
