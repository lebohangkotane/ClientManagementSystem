using ClientManagementSystem.DAL.Models;
using System.Collections.Generic;

namespace ClientManagementSystem.BAL
{
    public interface IClientService
    {
        int AddClient(Client client); 
        Client GetClient(int clientId); 
        List<Client> GetAllClients();
        void UpdateClient(Client client); 
        void DeleteClient(int clientId);
    }
}
