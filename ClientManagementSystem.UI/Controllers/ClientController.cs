using ClientManagementSystem.UI.ClientManagementServiceReference;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClientManagementSystem.UI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientManagementService _clientService;

        // Using Dependency Injection to pass the service client
        public ClientController(IClientManagementService clientService)
        {
            _clientService = clientService;
        }

        // GET: Client
        public async Task<ActionResult> Index()
        {
            var clients = await _clientService.GetAllClientsAsync();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                client.AddressTypes = await _clientService.GetAddressTypes();
                await _clientService.AddClientAsync(client);

                return Json(new { success = true });
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = await _clientService.GetClientAsync(id);

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
                try
                {
                    await _clientService.UpdateClientAsync(client);

                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError(string.Empty, $"An error occurred while updating the client: {ex.Message}");
                }
            }

            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _clientService.GetClientAsync(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName(nameof(DeleteConfirmed))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int ClientId)
        {
            try
            {
                await _clientService.DeleteClientAsync(ClientId);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                // Log the exception
                ModelState.AddModelError(string.Empty, $"An error occurred while deleting the client: {ex.Message}");

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
