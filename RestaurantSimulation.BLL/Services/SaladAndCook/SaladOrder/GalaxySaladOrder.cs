using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class GalaxySaladOrder : SaladOrder
    {
        public override VegetableSalad OrderSalad(IRestaurantCheaf p)
        {
            return p.OrderSalad(this);
        }
    }
}
