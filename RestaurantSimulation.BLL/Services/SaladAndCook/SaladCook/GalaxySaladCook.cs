using System.Collections.Generic;
using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladCook
{
    public class GalaxySaladCook : Cook
    {
        public override VegetableSalad MakeSalad(SaladOrder.SaladOrder galaxySalad)
        {
            var respire = new Dictionary<int, string>() { { 12, "Potatoo" }, { 14, "Ogurchik" }, { 22, "Morkov" } };

            var ingredient = VegetableStorage.GetVegetables(respire);

            foreach (var ing in ingredient)
            {
                VegetableSalad.Ingredients.Add(ing);
            }
            VegetableSalad.Name = "Vinaigrette";


            return VegetableSalad;
        }
    }
}
