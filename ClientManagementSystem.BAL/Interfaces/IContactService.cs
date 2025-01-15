using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.BAL.Interfaces
{
    public interface IContactService
    {
        int AddContactInfo(ContactInfo contactInfo);
        ContactInfo GetContactInfo(int contactInfoId);

        List<ContactType> GetAllContactTypes();

        List<ContactInfo> GetAllContactInfos();
        void UpdateContactInfo(ContactInfo contactInfo);
        void DeleteContactInfo(int contactInfoId);
    }
}
