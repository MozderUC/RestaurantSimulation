using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Services
{
    public abstract class SaladBuilder
    {
        public Models.VegetableSalad VegetableSalad { get; private set; }
        public RestaurantService Restaurant { get; set; }

        public void CreateVegetableSalad()
        {
            VegetableSalad = new Models.VegetableSalad();
        }
        public abstract void MakeSalad();
    }
}
