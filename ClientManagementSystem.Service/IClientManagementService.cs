using ClientManagementSystem.DAL.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClientManagementSystem.Service
{
    [ServiceContract]
    public interface IClientManagementService
    {
        [OperationContract]
        int AddClient(Client client);

        [OperationContract]
        Client GetClient(int clientId);

        [OperationContract]
        List<Client> GetAllClients();

        [OperationContract]
        void UpdateClient(Client client);

        [OperationContract]
        void DeleteClient(int clientId);


        [OperationContract]
        int AddAddress(Address address);

        [OperationContract]
        Address GetAddress(int addressId);

        [OperationContract]
        List<Address> GetAllAddresses();

        [OperationContract]
        List<Address> GetAllAddressesByClientId(int clientId);

        [OperationContract]
        List<AddressType> GetAllAddressTypes();

        [OperationContract]
        void UpdateAddress(Address address);

        [OperationContract]
        void DeleteAddress(int addressId);


        [OperationContract]
        int AddContact(ContactInfo contact);

        [OperationContract]
        ContactInfo GetContact(int contactInfoId);

        [OperationContract]
        List<ContactInfo> GetAllContacts();

        [OperationContract]
        void UpdateContact(ContactInfo contact);

        [OperationContract]
        void DeleteContact(int contactInfoId);

        [OperationContract]
        List<ContactType> GetAllContactTypes();
    }
}
