using InvoiceApi.Data;
using InvoiceApi.Models.Dto;
using InvoiceApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Repository
{
    public class CustomerInvoiceRepository : ICustomerInvoiceRepository
    {
        private readonly DataContext _context;
        public CustomerInvoiceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerInvoiceSummaryDto>> GetCustomerInvoiceSummaryAsync()
        {
            var customerInvoiceSummary = await _context.tblCustomer
                .Include(c => c.tblInvoice)
                .Select(c => new CustomerInvoiceSummaryDto
                {
                    CarRego = c.CarRego,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CarMake = c.CarMake,
                    CarModel = c.CarModel,
                    PaymentStatus = c.PaymentStatus,
                    InvoiceId = c.tblInvoice.FirstOrDefault().InvoiceId,
                    DateAdded = c.tblInvoice.FirstOrDefault().DateAdded,
                    IssueName = c.tblInvoice.FirstOrDefault().IssueName,
                    DueDate = c.tblInvoice.FirstOrDefault().DueDate,
                    TotalAmount = c.tblInvoice.FirstOrDefault().TotalAmount,
                    AmountPaid = c.tblInvoice.FirstOrDefault().AmountPaid
                }).ToListAsync();

            return customerInvoiceSummary;
        }
    }
}
