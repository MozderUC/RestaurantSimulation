using RestaurantSimulation.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public abstract class RecipeBuilder
    {
        public Models.VegetableSalad VegetableSalad { get; private set; }
        public EFUnitOfWork UnitOfWork;
        
        public void CreateVegetableSalad()
        {
            UnitOfWork = new EFUnitOfWork();
            VegetableSalad = new Models.VegetableSalad();
        }
        public abstract void MakeSalad();
    }
}
