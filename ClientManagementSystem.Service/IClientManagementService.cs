using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
    }
}
