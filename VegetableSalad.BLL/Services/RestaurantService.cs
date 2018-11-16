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
        public List<SaladBuilder> Menu { get; set; }
        public WaiterService Waiter { get; private set; }
        public List<Table> Tables { get; private set; }
        public Cheaf Cheaf { get;private set; }
        public List<Clients> ClientServices { get; set; }

        


        public RestaurantService()
        {
            Tables = new List<Table> { new Table { SeatcCount = 2, TableNumber = 1, Reserved = false },
                new Table { SeatcCount = 2, TableNumber = 2, Reserved = false },
                new Table { SeatcCount = 3, TableNumber = 3, Reserved = false },
                new Table { SeatcCount = 3, TableNumber = 4, Reserved = false } };

            Menu = new List<SaladBuilder> { new VinaigretteSalad {Restaurant = this, VegetableSalad = new Models.VegetableSalad} };
            Waiter = new WaiterService(Menu);
                     
            //Tables =new List<Table> {
            //new Table()}

            // Создать столики, официанты, меню
        }

        public WaiterService AddClients(int VisitorsNumber)
        {
            
            // Найти столик
            // Дать официанта
            // Вернуть созданный сервис
        }

        public WaiterService RemoveClients(int VisitorsNumber)
        {
            return Waiters[0];
            // Найти столик
            // Дать официанта
            // Вернуть созданный сервис
        }
    }
}
