using System.Collections.Generic;

namespace ClientManagementSystem.UI.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
