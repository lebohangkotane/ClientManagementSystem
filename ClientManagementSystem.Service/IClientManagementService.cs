using ClientManagementSystem.DAL.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClientManagementSystem.Service
{
    [ServiceContract]
    public interface IClientManagementService
    {
        [OperationContract]
        void AddClient(Client client);

        [OperationContract]
        Client GetClient(int clientId);

        [OperationContract]
        List<Client> GetAllClients();

        [OperationContract]
        void UpdateClient(Client client);

        [OperationContract]
        void DeleteClient(int clientId);


        [OperationContract]
        void AddAddress(Address address);

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
    }
}
