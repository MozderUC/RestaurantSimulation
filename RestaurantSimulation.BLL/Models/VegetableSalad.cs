using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Models
{
    public class VegetableSalad
    {
        public Dictionary<Vegetable, int> Ingredients { set; get; }
        public string Name { get; set; }
        public VegetableSalad()
        {
            Ingredients = new Dictionary<Vegetable, int>();
        }
    }
}
