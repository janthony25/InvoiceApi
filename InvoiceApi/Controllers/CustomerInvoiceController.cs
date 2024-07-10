using InvoiceApi.Models.Dto;
using InvoiceApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi.Controllers
{
    public class CustomerInvoiceController : Controller
    {
        private readonly ICustomerInvoiceRepository _customerInvoiceRepo;
        public CustomerInvoiceController(ICustomerInvoiceRepository customerInvoiceRepo)
        {
            _customerInvoiceRepo = customerInvoiceRepo;
        }

        [HttpGet("customerInvoiceSummary")]
        public async Task<IActionResult> GetCustomerInvoiceSummary()
        {
            var customerInvoice = await _customerInvoiceRepo.GetCustomerInvoiceSummaryAsync();
            return Ok(customerInvoice);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> AddInvoiceOnCustomer(int id, [FromBody] CustomerInvoiceDto customerInvoice)
        {
            try
            {
                await _customerInvoiceRepo.AddCustomerInvoiceAsync(id, customerInvoice);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured: " + ex.Message);
            }
        }
    }
}
