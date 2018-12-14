using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services
{
    public interface IRestaurantChief
    {
        VegetableSalad OrderSalad(VinaigretteSaladOrder vinaigrette);
        VegetableSalad OrderSalad(GalaxySaladOrder galaxy);
    }
}
