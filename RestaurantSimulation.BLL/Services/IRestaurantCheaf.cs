using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public interface IRestaurantCheaf
    {
        VegetableSalad OrderSalad(VinaigretteSaladOrder vinaigrette);
        VegetableSalad OrderSalad(GalaxySaladOrder galaxy);
    }
}
