using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesTransactionApi.Models;

namespace SalesTransactionApi.Repositories
{
    public interface ISalesTransactionService
    {
        public Task<List<SalesTransaction>> GetSalesTransactionListAsync();
        public Task<IEnumerable<SalesTransaction>> GetSalesTransactionByIdAsync(int Id);
        public Task<int> AddSalesTransactionAsync(SalesTransaction salesTransaction);
        public Task<int> UpdateSalesTransactionAsync(SalesTransaction salesTransaction);
        public Task<int> DeleteSalesTransactionAsync(int Id);
    }
}
