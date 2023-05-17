using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTransactionApi.Repositories;
using SalesTransactionApi.Models;

namespace SalesTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTransactionController : ControllerBase
    {
        private readonly ISalesTransactionService salesTransactionService;
        public SalesTransactionController(ISalesTransactionService salesTransactionService)
        {
            this.salesTransactionService = salesTransactionService;
        }
        [HttpGet("getsalestransactionlist")]
        public async Task<List<SalesTransaction>> GetSalesTransactionListAsync()
        {
            try
            {
                return await salesTransactionService.GetSalesTransactionListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getsalestransactionbyid")]
        public async Task<IEnumerable<SalesTransaction>> GetSalesTransactionByIdAsync(int Id)
        {
            try
            {
                var response = await salesTransactionService.GetSalesTransactionByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addsalestransaction")]
        public async Task<IActionResult> AddSalesTransactionAsync(SalesTransaction SalesTransaction)
        {
            if (SalesTransaction == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await salesTransactionService.AddSalesTransactionAsync(SalesTransaction);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatesalestransaction")]
        public async Task<IActionResult> UpdateSalesTransactionAsync(SalesTransaction SalesTransaction)
        {
            if (SalesTransaction == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await salesTransactionService.UpdateSalesTransactionAsync(SalesTransaction);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletesalestransaction")]
        public async Task<int> DeleteSalesTransactionAsync(int Id)
        {
            try
            {
                var response = await salesTransactionService.DeleteSalesTransactionAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
