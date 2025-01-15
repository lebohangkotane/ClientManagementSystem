using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClientManagementSystem.DAL.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int ClientId { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public string Occupation { get; set; }

        [DataMember]
        public ICollection<Address> Addresses { get; set; }
        
        [DataMember]
        public ICollection<ContactInfo> ContactInfos { get; set; }

        [DataMember]
        public ICollection<AddressType> AddressTypes { get; set; }
    }
}
