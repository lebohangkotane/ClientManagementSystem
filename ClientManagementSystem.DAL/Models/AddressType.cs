using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    [DataContract]
    public class AddressType
    {
        [DataMember]
        public int AddressTypeId { get; set; }
        
        [DataMember]
        public string TypeName { get; set; }
        
        [DataMember]
        public ICollection<Address> Addresses { get; set; }
    }
}
