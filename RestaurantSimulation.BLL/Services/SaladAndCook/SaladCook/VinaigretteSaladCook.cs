using System.Collections.Generic;
using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladCook
{
    public class VinaigretteSaladCook : Cook
    {
        public override VegetableSalad MakeSalad(SaladOrder.SaladOrder vinaigrette)
        {
            var respire = new Dictionary<int, string>() { {12,"Potatoo"},{14,"Ogurchik"},{22,"Morkov"} };

            //Get Ingredience from stotrage
            var ingredient = VegetableStorage.GetVegetables(respire);


            // Constract salad
            foreach (var ing in ingredient)
            {
                VegetableSalad.Ingredients.Add(ing);
            }            
            VegetableSalad.Name = "Vinaigrette";


            return VegetableSalad;
        }        
    }
}
