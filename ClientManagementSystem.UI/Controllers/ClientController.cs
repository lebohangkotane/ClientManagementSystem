using ClientManagementSystem.UI.ClientManagementServiceReference;
using ClientManagementSystem.UI.Helpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClientManagementSystem.UI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientManagementService _clientManagementService;

        // Using Dependency Injection to pass the service client
        public ClientController(IClientManagementService clientManagementService)
        {
            _clientManagementService = clientManagementService;
        }

        // GET: Client
        public async Task<ActionResult> Index()
        {
            var clients = await _clientManagementService.GetAllClientsAsync();

            var clientList = clients.Select(c => new Client
            {
                ClientId = c.ClientId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Gender = c.Gender,
                Occupation = c.Occupation,
                Nationality = c.Nationality,
            }).ToList();

            return View(clientList);
        }

        // GET: Client/Create
        public async Task<ActionResult> Create()
        {
            var addressTypes = await _clientManagementService.GetAllAddressTypesAsync();
            var contactTypes = await _clientManagementService.GetAllContactTypesAsync();

            var client = new Client
            {
                AddressTypes = addressTypes,
                Addresses = addressTypes.Select(x => new Address { AddressTypeId = x.AddressTypeId })
                                        .ToList(),
                ContactInfos = contactTypes.Select(ct => new ContactInfo { ContactTypeId = ct.ContactTypeId }).ToList(),
            };

            ViewBag.ContactTypes = contactTypes;

            return View(client);
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                var clientId = await _clientManagementService.AddClientAsync(client);

                //add addresses
                foreach (var address in client.Addresses)
                {
                    address.ClientId = clientId;
                    address.AddressTypeId = address.AddressTypeId;
                    await _clientManagementService.AddAddressAsync(address);
                }

                //add contactInfo
                foreach (var contactInfo in client.ContactInfos)
                {
                    contactInfo.ClientId = clientId;
                    await _clientManagementService.AddContactAsync(contactInfo);
                }

                return Json(new { success = true });
            }

            client.AddressTypes = await _clientManagementService.GetAllAddressTypesAsync();
            ViewBag.ContactTypes = await _clientManagementService.GetAllContactTypesAsync();

            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = await _clientManagementService.GetClientAsync(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                await _clientManagementService.UpdateClientAsync(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _clientManagementService.GetClientAsync(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName(nameof(DeleteConfirmed))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int clientId)
        {
            var clientAddresses = _clientManagementService.GetAllAddressesByClientId(clientId);
            var clientContactInfo = _clientManagementService.GetAllContacts().Where(x=>x.ClientId == clientId);

            foreach (var address in clientAddresses)
            {
                await _clientManagementService.DeleteAddressAsync(address.AddressId);
            }

            foreach (var contactInfo in clientContactInfo)
            {
                await _clientManagementService.DeleteContactAsync(contactInfo.ContactInfoId);
            }

            await _clientManagementService.DeleteClientAsync(clientId);

            return RedirectToAction(nameof(Index));
        }

        // Export Clients and Addresses to CSV
        public async Task<FileResult> Export()
        {
            ExportToCSV ExportToCSV = new ExportToCSV(); 

            var csvData = await ExportToCSV.GenerateExportToCSV();
            
            var result = new FileContentResult(csvData, "text/csv")
            {
                FileDownloadName = "ClientsAndAddresses.csv"
            };

            return result;
        }
    }
}
