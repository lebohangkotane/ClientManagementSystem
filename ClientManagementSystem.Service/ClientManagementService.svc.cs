using ClientManagementSystem.BAL;
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
        private readonly ClientService _clientService;

        public ClientManagementService()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClientManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            _clientService = new ClientService(connectionString);
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
    }
}
