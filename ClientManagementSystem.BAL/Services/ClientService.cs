using ClientManagementSystem.DAL;
using ClientManagementSystem.DAL.Models;
using ClientManagementSystem.DAL.Repositories;
using System.Collections.Generic;

namespace ClientManagementSystem.BAL
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(string connectionString)
        {
            _clientRepository = new ClientRepository(connectionString);
        }

        public void AddClient(Client client)
        {
            _clientRepository.AddClient(client);
        }
        public Client GetClient(int clientId)
        {
            return _clientRepository.GetClient(clientId);
        }
        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }
        public void DeleteClient(int clientId)
        {
            _clientRepository.DeleteClient(clientId);
        }
    }
}
