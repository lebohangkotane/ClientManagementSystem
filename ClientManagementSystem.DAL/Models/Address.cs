using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public int AddressId { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }
        
        [DataMember]
        public int AddressTypeId { get; set; }
        
        [DataMember]
        public string AddressDetail { get; set; }

        [DataMember]
        public Client Client { get; set; }
        
        [DataMember]
        public AddressType AddressType { get; set; }
    }
}
