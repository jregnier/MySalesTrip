using MySalesApp.Business.Models;
using System.Threading.Tasks;

namespace MySalesApp.Service.CustomerServices
{
    public interface ICustomerEditService
    {
        Task CreateAsync(CustomerEdit customer);

        Task EditAsync(CustomerEdit customer);

        Task<CustomerEdit> GetById(int id);

        CustomerEdit New();
    }
}
