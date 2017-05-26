using LiteDB;
using System.Collections.Generic;

namespace MySalesApp.Data.Entities
{
    public class CustomerEntity : IEntity
    {
        public int Id { get; set; }

        [BsonIndex(true)]
        public string Name { get; set; }

        public List<AddressEntity> Addresses { get; set; }
    }
}