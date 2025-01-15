using ClientManagementSystem.DAL.Models;
using System.Collections.Generic;

namespace ClientManagementSystem.BAL.Interfaces
{
    public interface IAddressService
    {
        void AddAddress(Address Address);
        
        Address GetAddress(int AddressId);
        
        List<Address> GetAllAddresses();

        List<Address> GetAllAddressesByClientId(int clientId);

        List<AddressType> GetAllAddressTypes();

        void UpdateAddress(Address Address);

        void DeleteAddress(int AddressId);
    }
}
