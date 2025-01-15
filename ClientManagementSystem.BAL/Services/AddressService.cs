using ClientManagementSystem.BAL.Interfaces;
using ClientManagementSystem.DAL.Models;
using ClientManagementSystem.DAL.Repositories;
using System.Collections.Generic;


namespace ClientManagementSystem.BAL.Services
{
    public class AddressService : IAddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(string connectionString)
        {
            _addressRepository = new AddressRepository(connectionString);
        }

        public int AddAddress(Address Address)
        {
            return _addressRepository.AddAddress(Address);
        }

        public Address GetAddress(int addressId)
        {
            return _addressRepository.GetAddress(addressId);
        }

        public List<Address> GetAllAddresses()
        {
            return _addressRepository.GetAllAddresses();
        }

        public List<AddressType> GetAllAddressTypes()
        {
            return _addressRepository.GetAllAddressTypes();
        }

        public List<Address> GetAllAddressesByClientId(int clientId)
        {
            return _addressRepository.GetAllAddressesByClientId(clientId);
        }

        public void UpdateAddress(Address Address)
        {
            _addressRepository.UpdateAddress(Address);
        }

        public void DeleteAddress(int AddressId)
        {
            _addressRepository.DeleteAddress(AddressId);
        }
    }
}
