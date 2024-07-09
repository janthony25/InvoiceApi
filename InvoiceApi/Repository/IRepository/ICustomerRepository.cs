using InvoiceApi.Models.Dto;
using InvoiceApi.Models.Entities;

namespace InvoiceApi.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerListDto>> GetCustomerSummaryAsync();

        Task AddCustomerAsync(CustomerDetailsDto customerDto);
        Task<CustomerDetailsDto> FindCustomerByIdAsync(int id);

        Task DeleteCustomerById(int id);
    }
}
