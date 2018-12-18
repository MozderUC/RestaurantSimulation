using RestaurantSimulation.BLL.Services.CustomExeptions;
using RestaurantSimulation.BLL.Utill;
using RestaurantSimulation.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSimulation.BLL.Services
{
    public class VegetableStorageService
    {
        private readonly IEFUnitOfWork _unitOfWork;
        public List<Models.Vegetable> Vegetables { get; set; }

        public VegetableStorageService()
        {
            _unitOfWork = new EFUnitOfWork();
            Vegetables = new List<Models.Vegetable>();
        }

        /// <summary>
        /// For testability
        /// </summary>
        /// <param name="unitOfWork"></param>     
        public VegetableStorageService(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Vegetables = new List<Models.Vegetable>();
        }

        public List<Models.Vegetable> GetVegetables(Dictionary<int, string> ingredients)
        {
            var storage = _unitOfWork.VegetableStorage.GetAll().ToList();
            foreach (var ing in ingredients)
            {                                  
                var foundVegetables = storage.Find(item => item.Vegetable.Name == ing.Value);
           
                if (foundVegetables == null)
                    throw new NotFoundIngredientException("");
                if (foundVegetables.VegetableStock < ing.Key)
                    throw new NoAmountNeededProductException(ing.ToString());

                var vegetable = MapperModule.EFVegetable_To_Vegetable(foundVegetables.Vegetable);
                vegetable.Weight = ing.Key;
                Vegetables.Add(vegetable);
            }

            return Vegetables;
        }
    }
}
