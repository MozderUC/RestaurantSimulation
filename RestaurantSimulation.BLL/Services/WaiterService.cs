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
        private readonly CheafService cheafService = new CheafService();

        public Dictionary<int, IList<SaladOrder>> TableOrder { get; set; }
      
        public WaiterService()
        {
            UnitOfWork = new EFUnitOfWork();
            TableOrder = new Dictionary<int, IList<SaladOrder>>();
        }

        public IEnumerable<Menu> GiveMenu()
        {
            // Выдать Меню
            var Menu = UnitOfWork.Menu.GetAll();
            return Menu;

        }

        public List<Models.VegetableSalad> TakeOrder(int TableNumber, IList<SaladOrder> Order)
        {
            
            TableOrder[TableNumber] = Order;           
            return cheafService.ProcessOrder(Order);

        }

        public void GiveBill(int TableNumber)
        {
            // Отдать счет           
            //var q = from d in TableOrder[TableNumber]
            //        join dc in UnitOfWork.Menu.GetAll() on d equals dc.Name
            //        select dc;
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
