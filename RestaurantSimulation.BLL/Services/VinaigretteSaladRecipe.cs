using RestaurantSimulation.BLL.Services.CustomExeptions;
using RestaurantSimulation.BLL.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class VinaigretteSaladRecipe : RecipeBuilder
    {
        public override void MakeSalad()
        {
            Dictionary<int, string> Resipie = new Dictionary<int, string>() { {12,"Potatoo"},{14,"Ogurchik"},{22,"Morkov"} };

            this.VegetableSalad.Ingredients = this.VegetableStorage.GetVegetables(Resipie);
            this.VegetableSalad.Name = "Vinaigrette";


            throw new NotImplementedException();
        }
    }
}
