using System;
using System.Collections.Generic;

namespace ClientManagementSystem.DAL.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }

        public ICollection<AddressType> AddressTypes { get; set; }
    }
}
