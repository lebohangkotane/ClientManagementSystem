using System.Collections.Generic;

namespace ClientManagementSystem.UI.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
