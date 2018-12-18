using Microsoft.AspNet.SignalR.Client;
using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Repositories;
using System.Collections.Generic;
using System.Threading;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder;

namespace RestaurantSimulation.BLL.Services
{
    public class WaiterService
    {
        readonly EFUnitOfWork _unitOfWork;
        private readonly ChiefService _chiefService = new ChiefService();

        public Dictionary<int, IList<SaladOrder>> TableOrder { get; set; }
      
        public WaiterService()
        {
            _unitOfWork = new EFUnitOfWork();
            TableOrder = new Dictionary<int, IList<SaladOrder>>();
        }

        public IEnumerable<Menu> GiveMenu()
        {
            // Выдать Меню
            var menu = _unitOfWork.Menu.GetAll();
            return menu;

        }

        public List<Models.VegetableSalad> TakeOrder(int tableNumber, IList<SaladOrder> order)
        {
            var connection = new HubConnection("http://localhost:56319/");
            var myHub = connection.CreateHubProxy("RestaurantHub");

            //connection.Start().Wait(); // not sure if you need this if you are simply posting to the hub           
            TableOrder[tableNumber] = order;

            //myHub.Invoke("AddNewMessageToPage", "Waiter get order to chef", tableNumber).Wait();
            //Thread.Sleep(4000);

            return _chiefService.ProcessOrder(order);

        }     

        public void TakeFeedback(string feedback, string name)
        {
            _unitOfWork.Guestbook.Create(new Guestbook() { Name = name, Review = feedback });
            _unitOfWork.Save();
        }        
    }
}
