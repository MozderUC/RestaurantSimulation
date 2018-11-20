using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class Cheaf
    {
        
        public static List<VegetableSalad> MakeOrder(List<string> Order)
        {
            List<VegetableSalad> ReadyOrder = new List<VegetableSalad>();
            foreach (string salad in Order)
            {
                switch (salad)
                {
                    case "Vinaigrette":
                        CookBuilder VinaigretteBuilder = new VinaigretteSaladCook();
                        ReadyOrder.Add(VinaigretteBuilder.MakeSalad());
                        break;
                    case "Galaxy":
                        CookBuilder GalaxyBuilder = new GalaxySaladCook();
                        ReadyOrder.Add(GalaxyBuilder.MakeSalad());
                        break;
                    default:                        
                        break;
                }

            }
            return ReadyOrder;
        }
    }
}
