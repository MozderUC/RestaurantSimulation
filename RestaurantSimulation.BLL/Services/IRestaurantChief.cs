using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder;

namespace RestaurantSimulation.BLL.Services
{
    public interface IRestaurantChief
    {
        VegetableSalad OrderSalad(VinaigretteSaladOrder vinaigrette);
        VegetableSalad OrderSalad(GalaxySaladOrder galaxy);
    }
}
