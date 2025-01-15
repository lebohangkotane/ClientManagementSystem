using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    [DataContract]
    public class ContactInfo
    {
        [DataMember]
        public int ContactInfoId { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }
        
        [DataMember]
        public int ContactTypeId { get; set; }
        
        [DataMember]
        public string ContactDetail { get; set; }
        

        [DataMember]
        public Client Client { get; set; }
        
        [DataMember]
        public ContactType ContactType { get; set; }
    }
}
