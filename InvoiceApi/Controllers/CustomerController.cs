using InvoiceApi.Models.Dto;
using InvoiceApi.Models.Entities;
using InvoiceApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("customerSummary")]
        public async Task<IActionResult> GetCustomerList()
        {
            var customerList = await _customerRepository.GetCustomerSummaryAsync();
            return Ok(customerList);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerDetailsDto customerDetailsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerRepository.AddCustomerAsync(customerDetailsDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.FindCustomerByIdAsync(id); 
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);    
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            await _customerRepository.DeleteCustomerById(id);
            return Ok();

        }
        
            
    }
}
