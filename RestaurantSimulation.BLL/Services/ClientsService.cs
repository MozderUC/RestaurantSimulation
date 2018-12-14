using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR.Client;
using System.Threading;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder;

namespace RestaurantSimulation.BLL.Services
{
    public class ClientsService
    {
        public int TableNumber { get; set; }
        public List<SaladOrder> TableOrder { get; set; }
        public bool IsCreatedBill { get; set; } = false;

        public WaiterService WaiterService { get; set; }

        public IEnumerable<Menu> GetMenu()
        {
            return WaiterService.GiveMenu();
        }

        public List<VegetableSalad> MakeOrder(IList<SaladOrder> order)
        {

            var connection = new HubConnection("http://localhost:56319/");
            var myHub = connection.CreateHubProxy("RestaurantHub");
            
            connection.Start().Wait(); // not sure if you need this if you are simply posting to the hub
            myHub.Invoke("AddNewMessageToPage", "Waiter get your order", TableNumber).Wait();
            Thread.Sleep(4000);

            TableOrder = order.ToList();
            return WaiterService.TakeOrder(TableNumber, order);
        }

        public void GetBill()
        {
            //return WaiterService.GiveBill(TableNumber);
        }


        public void LeaveFeedback(string feedback, string name)
        {
            WaiterService.TakeFeedback(feedback, name);
        }

        public void LeaveRestaurant()
        {                   
        }
    }
}
