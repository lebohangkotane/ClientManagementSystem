using ClientManagementSystem.BAL.Interfaces;
using ClientManagementSystem.DAL.Models;
using ClientManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.BAL.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _contactRepository;

        public ContactService(string connnectionString)
        {
            _contactRepository = new ContactRepository(connnectionString);
        }
        public int AddContactInfo(ContactInfo ContactInfo)
        {
            return _contactRepository.AddContact(ContactInfo);
        }

        public void DeleteContactInfo(int contactInfoId)
        {
            _contactRepository.DeleteContact(contactInfoId);
        }

        public List<ContactInfo> GetAllContactInfos()
        {
            return _contactRepository.GetAllContacts();
        }

        public List<ContactType> GetAllContactTypes()
        {
            return _contactRepository.GetAllContactTypes();
        }

        public ContactInfo GetContactInfo(int contactInfoId)
        {
            return _contactRepository.GetContact(contactInfoId);
        }

        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            _contactRepository.UpdateContact(contactInfo);
        }
    }
}
