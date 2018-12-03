using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.TableOrder = order.ToList();
            return WaiterService.TakeOrder(TableNumber, order);
        }

        public void GetBill()
        {
            //return WaiterService.GiveBill(TableNumber);
        }


        public void LeaveFeedback(string feedback, string Name)
        {
            WaiterService.TakeFeedback(feedback, Name);
        }

        public void LeaveRestaurant()
        {                   
        }
    }
}
