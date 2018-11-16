using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Services
{
    public class Clients
    {
        public int TableNumber { get; set; }
        public WaiterService WaiterService { get; set; }

        public void GetMenu ()
        {
            // Попросить у WaiterService меню
            // Вернуть меню
        }

        public void MakeOrder(List<string> order)
        {
            // Сделать заказ у WaiterService
            // Вернуть сообщение заказ принят/не_принят
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

        public void LeaveRestaurant ()
        {
            // Попросить счет
            // Заплатить по счету
        }

    }
}
