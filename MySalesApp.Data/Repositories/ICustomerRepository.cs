using MySalesApp.Data.Entities;

namespace MySalesApp.Data.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        CustomerEntity GetByName(string name);
    }
}
