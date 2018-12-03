using RestaurantSimulation.BLL.Services;
using RestaurantSimulation.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace RestaurantSimulation.WEB.Controllers
{
    public class HomeController : Controller
    {
        //private static readonly IList<ClientServiceViewModel> clientServiceViewModels;
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
            return Json(clientServices.Select(foo=>new {foo.TableNumber,foo.TableOrder,foo.IsCreatedBill}), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult GetRestarauntMenu()
        {
            return Json(restarauntMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddClientsService(int clientAmount)
        {
            var clients = clientsRegistrationService.AddClients(clientAmount);
            clientServices.Add(clients);                   

            return Content("Success :)");
        }

       
        public ActionResult AddClientOrder(int tableNumber, string order)
        {
            List<string> orders = order.Split(',').ToList<string>();        
            var clientOrder = restarauntMenu.Join(orders,
                                 r => r.Dish,
                                 o1 => o1,
                                 (r, o1) => r).ToList();

            var client = clientServices.First(foo => foo.TableNumber == tableNumber);
            client.MakeOrder(clientOrder);
                                 
            return Content("Success :)");
        }
        public ActionResult GetClientBill(int tableNumber)
        {
            var currentClientServices = clientServices.First(foo => foo.TableNumber == tableNumber);
            currentClientServices.IsCreatedBill = true;
                     
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}