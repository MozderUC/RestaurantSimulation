using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    abstract public class Cook
    {
        public Models.VegetableSalad VegetableSalad { get; private set; }
        public VegetableStorageService VegetableStorage { get; set; }

        public Cook()
        {
            VegetableSalad = new Models.VegetableSalad();
            VegetableStorage = new VegetableStorageService();
        }
        
        public abstract VegetableSalad MakeSalad(SaladOrder order);
    }
}
