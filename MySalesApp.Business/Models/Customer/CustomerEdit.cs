using System.Collections.Generic;

namespace MySalesApp.Business.Models
{
    public class CustomerEdit
    {
        public List<Address> Addresses { get; set; }
        public List<Contact> Contacts { get; set; }
        public int Id { get; }
        public string Name { get; set; }
    }
}