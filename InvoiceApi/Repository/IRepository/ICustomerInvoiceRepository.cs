using InvoiceApi.Models.Dto;
using InvoiceApi.Models.Entities;

namespace InvoiceApi.Repository.IRepository
{
    public interface ICustomerInvoiceRepository
    {
        Task<List<CustomerInvoiceSummaryDto>> GetCustomerInvoiceSummaryAsync();
        Task AddCustomerInvoiceAsync(int id,CustomerInvoiceDto customerInvoice);
    }
}
