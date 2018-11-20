using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class Clients
    {
        public int TableNumber { get; set; }
        public WaiterService WaiterService { get; set; }

        public IEnumerable<Menu> GetMenu()
        {
            return WaiterService.GiveMenu();
        }

        public List<VegetableSalad> MakeOrder(List<string> order)
        {
            return WaiterService.TakeOrder(TableNumber, order);
        }

        public void GetBill()
        {
            // Попросить счет
            // Заплатить по счету
        }


        public void LeaveFeedback(string feedback)
        {
            // Попросить у WaiterService книгу отзывов
            // Записать отзыв
        }

        public void LeaveRestaurant()
        {
            // Попросить счет
            // Заплатить по счету
        }
    }
}
