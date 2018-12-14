using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class ChiefService : IRestaurantChief
    {
        private readonly VinaigretteSaladCook vinaigretteSaladCook = new VinaigretteSaladCook();
        private readonly GalaxySaladCook galaxySaladCook  = new GalaxySaladCook();
        readonly List<VegetableSalad> ReadyOrder = new List<VegetableSalad>();

        
        public VegetableSalad OrderSalad(VinaigretteSaladOrder vinaigrette)
        {
            return vinaigretteSaladCook.MakeSalad(vinaigrette);
        }

        public VegetableSalad OrderSalad(GalaxySaladOrder galaxy)
        {
            return galaxySaladCook.MakeSalad(galaxy);
        }

        public List<VegetableSalad> ProcessOrder(IList<SaladOrder> orders)
        {
            foreach (var order in orders)
            {
                ReadyOrder.Add(order.OrderSalad(this));
            }

            return ReadyOrder;
        }
    }
}
