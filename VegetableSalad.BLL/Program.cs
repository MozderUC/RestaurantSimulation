using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Services;

namespace VegetableSalad.BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantService restaurant = new RestaurantService();
            WaiterService service = restaurant.AddClients(4);
            List<Models.VegetableSalad> menu = service.Restaurant.Menu;
        }
    }
}
