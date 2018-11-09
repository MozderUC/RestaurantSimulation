using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Interfaces;
using VegetableSalad.DAL.Repositories;
using VegetableSalad.DAL.Entities;
using VegetableSalad.BLL.Models;
using VegetableSalad.BLL.Utill;

namespace VegetableSalad.BLL.Services
{
    public class SalatService
    {
        private IVegetableRepository<VegetableEntity> VegetableRepository { get; set; }

        private List<Vegetable> Vegetables { get; set; }
        private Models.VegetableSalad VegetableSalad { get; set; }

        public SalatService(IVegetableRepository<DAL.Entities.VegetableEntity> _vegetable)
        {
            VegetableRepository = _vegetable;

            // Create list of vegetables
            var Vegetables = VegetableRepository.GetAll();
            this.Vegetables = new List<Vegetable>();
            this.Vegetables.AddRange(MapperModule.VegetableEntity_To_Vegetable(Vegetables));

            VegetableSalad = new Models.VegetableSalad();
        }

        public void SetSaladName(string saladName)
        {
            VegetableSalad.Name = saladName;
        }

        public void AddIngredient(string IngredientName, int amount)
        {

            var foundIngredient = Vegetables.Find(foo => foo.Name == IngredientName);
            if (foundIngredient!=null)
            {
                var existIngredient = VegetableSalad.Ingredients.FirstOrDefault(foo => foo.Key.Name == IngredientName);
                if (existIngredient.Key != null)
                {
                    VegetableSalad.Ingredients[existIngredient.Key] += amount;
                }
                else
                {
                    VegetableSalad.Ingredients.Add(foundIngredient, amount);
                }
            }
        }

        public float CountCalories ()
        {
            var countCalories = VegetableSalad.Ingredients.Select(foo=> foo.Key.Calories).Sum();
            return countCalories;
        }

        public void SortIngredientsByCalories()
        {
            var sortedWords = VegetableSalad.Ingredients.OrderBy(a=> a.Key.Calories);
        }
    }
}
