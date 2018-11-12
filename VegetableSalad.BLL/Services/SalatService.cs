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
using VegetableSalad.BLL.Interfaces;
using Ninject;
using System.IO;

namespace VegetableSalad.BLL.Services
{
    public class SalatService : ISalatService
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IUnitOfWork UnitOfWork { get; set; }

        private List<Vegetable> Vegetables { get; set; }
        private Models.VegetableSalad VegetableSalad { get; set; }

        public SalatService()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            UnitOfWork = kernel.Get<IUnitOfWork>();
            
            // Create list of vegetables
            try
            {
                var Vegetables = UnitOfWork.Vegetables.GetAll();
                this.Vegetables = new List<Vegetable>();
                this.Vegetables.AddRange(MapperModule.VegetableEntity_To_Vegetable(Vegetables));
            }          
            catch (SystemException ex)
            {
                logger.Fatal(ex, "Exeption occured when get vegetables data");
                throw;
            }

            VegetableSalad = new Models.VegetableSalad();
        }

        public void SetSaladName(string saladName)
        {           
            VegetableSalad.Name = saladName;
        }

        public bool AddIngredient(string IngredientName, int amount)
        {
            var foundIngredient = Vegetables.Find(foo => foo.Name == IngredientName);
            if (foundIngredient != null)
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public float CountCalories ()
        {
            var countCalories = VegetableSalad.Ingredients.Select(foo=> foo.Key.Calories/100*foo.Value).Sum();
            return countCalories;
        }

        public bool SortIngredientsByCalories()
        {
            VegetableSalad.Ingredients = VegetableSalad.Ingredients.OrderBy(a=> a.Key.Calories/100*a.Value).ToDictionary(t => t.Key, t => t.Value);
            return true;

        }

        public override string ToString()
        {
            string data = "Salat Name: "+VegetableSalad.Name+"\nSalat Ingregiens(ingredience, amount):\n";
            foreach(var ing in VegetableSalad.Ingredients)
            {
                data += ing.Key.Name+" || "+ing.Value+"\n";
            }
            return data;
        }

        public Models.VegetableSalad GetSalatObject()
        {
            return (Models.VegetableSalad)VegetableSalad.Clone();
        }
    }
}
