using ClientManagementSystem.BAL;
using ClientManagementSystem.BAL.Interfaces;
using ClientManagementSystem.BAL.Services;
using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientManagementSystem.Service
{
    public class ClientManagementService : IClientManagementService
    {
        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;
        private readonly IContactService _contactService;

        public ClientManagementService()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClientManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
           
            _clientService = new ClientService(connectionString);
            _addressService = new AddressService(connectionString);
            _contactService = new ContactService(connectionString);
        }

        public int AddClient(Client client)
        {
            return _clientService.AddClient(client);
        }

        public Client GetClient(int clientId)
        {
            return _clientService.GetClient(clientId);
        }

        public List<Client> GetAllClients()
        {
            return _clientService.GetAllClients();
        }

        public void UpdateClient(Client client)
        {
            _clientService.UpdateClient(client);
        }

        public void DeleteClient(int clientId)
        {
            _clientService.DeleteClient(clientId);
        }


        public int AddAddress(Address address)
        { 
            return _addressService.AddAddress(address);
        }

        public Address GetAddress(int addressId)
        {
            return _addressService.GetAddress(addressId);
        }

        public List<Address> GetAllAddressesByClientId(int clientId)
        {
            return _addressService.GetAllAddressesByClientId(clientId);
        }

        public List<Address> GetAllAddresses()
        {
            return _addressService.GetAllAddresses();
        }

        public List<AddressType> GetAllAddressTypes()
        {
            return _addressService.GetAllAddressTypes();
        }

        public void UpdateAddress(Address address)
        {
            _addressService.UpdateAddress(address);
        }

        public void DeleteAddress(int addressId)
        {
            _addressService.DeleteAddress(addressId);
        }

        public int AddContact(ContactInfo contact)
        {
            return _contactService.AddContactInfo(contact);
        }

        public ContactInfo GetContact(int contactInfoId)
        {
            return _contactService.GetContactInfo(contactInfoId);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _contactService.GetAllContactInfos();
        }

        public void UpdateContact(ContactInfo contact)
        {
            _contactService.UpdateContactInfo(contact);
        }

        public void DeleteContact(int contactInfoId)
        {
            _contactService.DeleteContactInfo(contactInfoId);
        }

        public List<ContactType> GetAllContactTypes()
        {
            return _contactService.GetAllContactTypes();
        }
    }
}
