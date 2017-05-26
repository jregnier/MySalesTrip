using MySalesApp.Business.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySalesApp.Service.CustomerServices
{
    public interface ICustomerListService
    {
        Task<List<CustomerList>> GetAllAsync();
    }
}
