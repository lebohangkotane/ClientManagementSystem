using ClientManagementSystem.UI.ClientManagementServiceReference;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.UI.Helpers
{
    public class ExportToCSV
    {
        private readonly ClientManagementServiceClient clientManagementService = new ClientManagementServiceClient();

        public async Task<byte[]> GenerateExportToCSV()
        {
            var clients = await clientManagementService.GetAllClientsAsync();
            foreach (var client in clients)
            {
                client.Addresses = await clientManagementService.GetAllAddressesByClientIdAsync(client.ClientId);
            }

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("ClientId,FirstName,LastName,Gender,Nationality,Occupation,AddressTypeId,AddressDetail");

            foreach (var client in clients)
            {
                foreach (var address in client.Addresses)
                {
                    var csvLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", client.ClientId, client.FirstName, client.LastName, client.Gender, client.Nationality, client.Occupation, address.AddressTypeId, address.AddressDetail);
                    csvBuilder.AppendLine(csvLine);
                }
            }

            var csvData = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            return csvData;
        }
    }
}