using RestaurantSimulation.BLL.Models;
using System.Collections.Generic;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladCook;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder;

namespace RestaurantSimulation.BLL.Services
{
    public class ChiefService : IRestaurantChief
    {
        private readonly VinaigretteSaladCook _vinaigretteSaladCook = new VinaigretteSaladCook();
        private readonly GalaxySaladCook _galaxySaladCook  = new GalaxySaladCook();
        private readonly List<VegetableSalad> _readyOrder = new List<VegetableSalad>();

        
        public VegetableSalad OrderSalad(VinaigretteSaladOrder vinaigrette)
        {
            return _vinaigretteSaladCook.MakeSalad(vinaigrette);
        }

        public VegetableSalad OrderSalad(GalaxySaladOrder galaxy)
        {
            return _galaxySaladCook.MakeSalad(galaxy);
        }

        public List<VegetableSalad> ProcessOrder(IList<SaladOrder> orders)
        {
            foreach (var order in orders)
            {
                _readyOrder.Add(order.OrderSalad(this));
            }

            return _readyOrder;
        }
    }
}
