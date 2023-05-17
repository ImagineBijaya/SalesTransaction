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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService )
        {
            _customerService = customerService;
        }
        [HttpGet("getcustomerlist")]
        public async Task<List<Customer>> GetCustomerListAsync()
        {
            try
            {
                return await _customerService.GetCustomerListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getcustomerbyid")]
        public async Task<IEnumerable<Customer>> GetCustomerByIdAsync(int Id)
        {
            try
            {
                var response = await _customerService.GetCustomerByIdAsync(Id);

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

        [HttpPost("addcustomer")]
        public async Task<IActionResult> AddCustomerAsync(Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _customerService.AddCustomerAsync(Customer);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateCustomer")]
        public async Task<IActionResult> UpdateCustomerAsync(Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _customerService.UpdateCustomerAsync(Customer);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deleteCustomer")]
        public async Task<int> DeleteCustomerAsync(int Id)
        {
            try
            {
                var response = await _customerService.DeleteCustomerAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}