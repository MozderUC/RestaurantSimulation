using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class WaiterService
    {
        EFUnitOfWork UnitOfWork;

        public Dictionary<int, List<string>> TableOrder { get; set; }
        
        public WaiterService()
        {
            UnitOfWork = new EFUnitOfWork();
        }

        public IEnumerable<Menu> GiveMenu()
        {
            // Выдать Меню
            var Menu = UnitOfWork.Menu.GetAll();
            return Menu;

        }

        public List<Models.VegetableSalad> TakeOrder(int TableNumber, List<string> Order)
        {
            
            TableOrder[TableNumber] = Order;
            return Cheaf.MakeOrder(Order);

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
