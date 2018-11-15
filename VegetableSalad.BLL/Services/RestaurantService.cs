using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Models;

namespace VegetableSalad.BLL.Services
{
    public class RestaurantService
    {
        public List<Models.VegetableSalad> Menu { get; set; }
        public List<Waiter> Waiters { get; set; }
        public List<Table> Tables { get; set; }

        public RestaurantService()
        {
            // Создать столики, официанты, меню
        }

        public void AddClients(int VisitorsNumber)
        {
            // Найти столик
            // Дать официанта
            // Вернуть созданный сервис
        }
    }
}
