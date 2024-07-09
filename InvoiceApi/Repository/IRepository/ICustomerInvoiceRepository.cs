using InvoiceApi.Models.Dto;

namespace InvoiceApi.Repository.IRepository
{
    public interface ICustomerInvoiceRepository
    {
        Task<List<CustomerInvoiceSummaryDto>> GetCustomerInvoiceSummaryAsync();
    }
}
