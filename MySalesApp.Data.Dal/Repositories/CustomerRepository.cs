using LiteDB;
using MySalesApp.Data.Entities;
using MySalesApp.Data.Repositories;

namespace MySalesApp.Data.Dal.Repositories
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(LiteDatabase db)
            : base(db, "customers")
        {
        }

        public CustomerEntity GetByName(string name)
        {
            var customers = LiteDatabase.GetCollection<CustomerEntity>(CollectionName);
            return customers.FindOne(c => c.Name == name);
        }
    }
}