using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class GalaxySaladRecipe : RecipeBuilder
    {
        public override VegetableSalad MakeSalad()
        {
            Dictionary<int, string> Resipie = new Dictionary<int, string>() { { 12, "Potatoo" }, { 14, "Ogurchik" }, { 22, "Morkov" } };

            this.VegetableSalad.Ingredients = this.VegetableStorage.GetVegetables(Resipie);
            this.VegetableSalad.Name = "Galaxy";


            return this.VegetableSalad;
        }
    }
}
