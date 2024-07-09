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
    }
}
