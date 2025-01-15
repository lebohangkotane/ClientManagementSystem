using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
