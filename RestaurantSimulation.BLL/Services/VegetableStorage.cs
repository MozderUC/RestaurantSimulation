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
        public List<Models.Vegetable> Vegetables { get; set; }

        public VegetableStorage()
        {
            UnitOfWork = new EFUnitOfWork();
        }

        public List<Models.Vegetable> GetVegetables(Dictionary<int,string> ingrediense)
        {

            foreach(var ing in ingrediense)
            {
                var FoundVegetables = UnitOfWork.VegetableStorage.Find(item => item.Vegetable.Name == ing.Value).FirstOrDefault();
                if (FoundVegetables == null)
                    throw new NotFoundIngredienceExeption("");
                if (FoundVegetables.VegetableStock < ing.Key)
                    throw new NoAmountNeededProduct("");
               
                Models.Vegetable vegetable = MapperModule.EFVegetable_To_Vegetable(FoundVegetables.Vegetable);
                vegetable.Weight = ing.Key;
                Vegetables.Add(vegetable);
            }

            return Vegetables;
        }

    }
}
