using Newtonsoft.Json;
using RestaurantSimulation.BLL.Services;
using RestaurantSimulation.BLL.Services.CustomExeptions;
using RestaurantSimulation.WEB.Hubs;
using RestaurantSimulation.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace RestaurantSimulation.WEB.Controllers
{
    public class HomeController : Controller
    {       
        private static readonly IList<ClientsService> clientServices;
        private static readonly IList<SaladOrder> restarauntMenu;

        private static ClientsRegistrationService clientsRegistrationService { get; set; } = new ClientsRegistrationService();
       
        static HomeController()
        {          
            restarauntMenu = new List<SaladOrder>
            {
                new VinaigretteSaladOrder(),
                new GalaxySaladOrder()
            };

            clientServices = new List<ClientsService>()
            {
                //new ClientsService() { TableNumber =1, TableOrder = new List<SaladOrder>(){ new VinaigretteSaladOrder(), new GalaxySaladOrder()}, WaiterService = new WaiterService(){ TableOrder = new Dictionary<int, IList<SaladOrder>>(){{1, new List<SaladOrder>(){ new VinaigretteSaladOrder(), new GalaxySaladOrder() } }}} }
            };
           
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult GetClientsServices()
        {
            return Json(clientServices.Select(foo=>new {foo.TableNumber,foo.TableOrder,foo.IsCreatedBill, Message = ""}), JsonRequestBehavior.AllowGet);
        }
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult GetRestarauntMenu()
        {
            return Json(restarauntMenu, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddClientsService(int clientAmount)
        {
            try
            {
                var clients = clientsRegistrationService.AddClients(clientAmount);
                clientServices.Add(clients);
            }
            catch (TableNotFoundExeption e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }


            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddClientOrder(int tableNumber, string order)
        {
            List<string> orders = order.Split(',').ToList<string>();        
            var clientOrder = restarauntMenu.Join(orders,
                                 r => r.Dish,
                                 o1 => o1,
                                 (r, o1) => r).ToList();

            var client = clientServices.First(foo => foo.TableNumber == tableNumber);

            SendMessage("Client Order going to Cheaf", tableNumber);
            Thread.Sleep(5000);
            
            client.MakeOrder(clientOrder);                                
            return Content("Success :)");
        }
        private void SendMessage(string message,int tableNumber)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<RestarauntHub>();
            // отправляем сообщение           
            context.Clients.All.displayMessage(JsonConvert.SerializeObject(clientServices.Select(foo => foo.TableNumber == tableNumber ? new { foo.TableNumber, foo.TableOrder, foo.IsCreatedBill, Message = message } : new { foo.TableNumber, foo.TableOrder, foo.IsCreatedBill, Message = "" }).ToList()));
        }
        public ActionResult GetClientBill(int tableNumber)
        {
            var currentClientServices = clientServices.First(foo => foo.TableNumber == tableNumber);
            currentClientServices.IsCreatedBill = true;

            SendMessage("Waiter count your bill", tableNumber);
            Thread.Sleep(2000);
            return View();
        }

        public ActionResult RemoveClients(int tableNumber)
        {
            clientsRegistrationService.RemoveClients(tableNumber);

            var itemToRemove = clientServices.Single(r => r.TableNumber == tableNumber);
            clientServices.Remove(itemToRemove);

            return Content("Success :)");
        }

        public ActionResult Index()
        {
            return View();
        }
      
    }
}