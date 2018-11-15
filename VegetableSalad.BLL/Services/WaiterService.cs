using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Services
{
    public class WaiterService
    {
        public Dictionary<int, List<string>> TableOrder { get; set; }


        public void GiveMenu()
        {
            // Выдать Меню
        }

        public void TakeOrder()
        {
            // Принять заказ
            // Отдать заказ повару
        }

        public void GiveBill()
        {
            // Отдать счет
        }

        public void GiveRewiewBook()
        {
            // Дать книгу отзывов           
        }

        public void TakeBill()
        {
            // Забрать счет, отдать деньги в кассу   
        }

    }
}
