using InvoiceApi.Data;
using InvoiceApi.Models.Dto;
using InvoiceApi.Models.Entities;
using InvoiceApi.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _datacontext;
        public CustomerRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public async Task AddCustomerAsync(CustomerDetailsDto customerDto)
        {
            var customer = new tblCustomer
            {
                CarRego = customerDto.CarRego,
                CustomerName = customerDto.CustomerName,
                CarMake = customerDto.CarMake,
                CarModel = customerDto.CarModel,
                PaymentStatus = customerDto.PaymentStatus
            };

            await _datacontext.tblCustomer.AddAsync(customer);
            await _datacontext.SaveChangesAsync();
        }

        public async Task DeleteCustomerById(int id)
        {
            var customer = await _datacontext.tblCustomer.FindAsync(id);
            if(customer != null)
            {
                _datacontext.Remove(customer);
                await _datacontext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Customer with id: {customer.CustomerId} could not be found");
            }
        }

        public async Task<CustomerDetailsDto> FindCustomerByIdAsync(int id)
        {
            var customer = await _datacontext.tblCustomer.FindAsync(id);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDetailsDto
            {
                CarRego = customer.CarRego,
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CarMake = customer.CarMake,
                CarModel = customer.CarModel,
            };
        }

        public async Task<List<CustomerListDto>> GetCustomerSummaryAsync()
        {
            var customerList = await _datacontext.tblCustomer
                .Select(c => new CustomerListDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CarMake = c.CarMake,
                    CarModel = c.CarModel
                }).ToListAsync();

            return customerList;
        }

       
    }
}
