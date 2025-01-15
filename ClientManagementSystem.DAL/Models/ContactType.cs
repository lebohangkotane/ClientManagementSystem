using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.DAL.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
