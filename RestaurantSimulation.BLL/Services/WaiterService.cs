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

        public float GiveBill(int TableNumber)
        {
            // Count bill sum for a specific table

            var MakeBill = TableOrder[TableNumber].Join(UnitOfWork.Menu.GetAll(),
                                 order => order.Name,
                                 menuItem => menuItem.Name,
                                 (order, menuItem) => menuItem.Cost).Sum();
            return MakeBill;
        }

        public void TakeFeedback(string feedback, string Name)
        {
            UnitOfWork.Guestbook.Create(new Guestbook() { Name = Name, Review = feedback });
            UnitOfWork.Save();
        }

        public void TakeBill()
        {
            // Забрать счет, отдать деньги в кассу   
        }
    }
}
