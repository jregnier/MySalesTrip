using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySalesApp.Business.Models.Customer;
using MySalesApp.Data.Repositories;

namespace MySalesApp.Service.CustomerServices
{
    public class CustomerListService : ICustomerListService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerListService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerList>> GetAllAsync()
        {
            var customers = await Task.Run(() => _customerRepository.GetAll());

            return customers.Select(c => new CustomerList()
            {
                Name = c.Name
            })
            .ToList();
        }
    }
}
