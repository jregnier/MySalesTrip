namespace MySalesApp.Data.Entities
{
    public class ContactEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
    }
}