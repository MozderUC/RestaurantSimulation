using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public abstract class CookBuilder
    {
        public Models.VegetableSalad VegetableSalad { get; private set; }
        public VegetableStorage VegetableStorage { get; set; }
        
        public void CreateVegetableSalad()
        {           
            VegetableSalad = new Models.VegetableSalad();
            VegetableStorage = new VegetableStorage();
        }
        public abstract VegetableSalad MakeSalad();
    }
}
