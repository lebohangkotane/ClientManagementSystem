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

        public ClientManagementService()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClientManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            _clientService = new ClientService(connectionString);
            _addressService = new AddressService(connectionString);
        }

        public void AddClient(Client client)
        {
            _clientService.AddClient(client);
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


        public void AddAddress(Address address)
        { 
            _addressService.AddAddress(address);
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
    }
}
