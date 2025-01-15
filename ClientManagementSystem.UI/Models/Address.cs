namespace ClientManagementSystem.UI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressDetail { get; set; }

        public Client Client { get; set; }
        public AddressType AddressType { get; set; }
    }
}
