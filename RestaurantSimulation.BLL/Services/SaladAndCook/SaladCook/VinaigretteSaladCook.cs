using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services.CustomExeptions;
using RestaurantSimulation.BLL.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class VinaigretteSaladCook : Cook
    {
        public override VegetableSalad MakeSalad(SaladOrder vinaigrette)
        {
            Dictionary<int, string> Resipie = new Dictionary<int, string>() { {12,"Potatoo"},{14,"Ogurchik"},{22,"Morkov"} };

            //Get Ingredience from stotrage
            List<Vegetable> ingredience = VegetableStorage.GetVegetables(Resipie);


            // Constract salad
            foreach (var ing in ingredience)
            {
                this.VegetableSalad.Ingredients.Add(ing);
            }            
            this.VegetableSalad.Name = "Vinaigrette";


            return this.VegetableSalad;
        }        
    }
}
