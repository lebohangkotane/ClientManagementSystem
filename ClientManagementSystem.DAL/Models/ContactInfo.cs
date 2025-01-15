using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public int ClientId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactDetail { get; set; }

        public Client Client { get; set; }
        public ContactType ContactType { get; set; }
    }
}
