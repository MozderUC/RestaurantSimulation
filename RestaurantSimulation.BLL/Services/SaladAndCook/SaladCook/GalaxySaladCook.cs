using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class GalaxySaladCook : Cook
    {
        public override VegetableSalad MakeSalad(SaladOrder galaxySalad)
        {
            Dictionary<int, string> Resipie = new Dictionary<int, string>() { { 12, "Potatoo" }, { 14, "Ogurchik" }, { 22, "Morkov" } };

            List<Vegetable> ingredience = this.VegetableStorage.GetVegetables(Resipie);

            foreach (var ing in ingredience)
            {
                this.VegetableSalad.Ingredients.Add(ing);
            }
            this.VegetableSalad.Name = "Vinaigrette";


            return this.VegetableSalad;
        }
    }
}
