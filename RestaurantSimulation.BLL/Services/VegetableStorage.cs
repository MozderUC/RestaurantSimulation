using RestaurantSimulation.BLL.Services.CustomExeptions;
using RestaurantSimulation.BLL.Utill;
using RestaurantSimulation.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class VegetableStorage
    {
        public EFUnitOfWork UnitOfWork;
        public Dictionary<Models.Vegetable, int> Vegetables { get; set; }

        public VegetableStorage()
        {
            UnitOfWork = new EFUnitOfWork();
        }

        public Dictionary<Models.Vegetable, int> GetVegetables(Dictionary<int,string> ingrediense)
        {

            foreach(var ing in ingrediense)
            {
                var FoundVegetables = UnitOfWork.VegetableStorage.Find(item => item.Vegetable.Name == ing.Value).FirstOrDefault();
                if (FoundVegetables == null)
                    throw new NotFoundIngredienceExeption("");
                if (FoundVegetables.VegetableStock < ing.Key)
                    throw new NoAmountNeededProduct("");

                Vegetables.Add(MapperModule.EFVegetable_To_Vegetable(FoundVegetables.Vegetable));
            }

            return Vegetables;
        }

    }
}
