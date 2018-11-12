using Ninject;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Interfaces;
using VegetableSalad.CMD.Utill;
using System.IO;

namespace VegetableSalad.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Ioc
            IKernel kernel = new StandardKernel(new Bindings());

            ISalatService salatService;
            
           
            // Resolve dependense
            salatService = kernel.Get<ISalatService>();
            
            salatService.SetSaladName("My salat");
            
            salatService.AddIngredient("Cucumber",12);
            salatService.AddIngredient("Cucumber", 12);
            salatService.AddIngredient("Cabbage", 32);
            salatService.AddIngredient("Tomato", 28);
            
            Console.WriteLine(salatService.ToString());
            
            
            float TotalCalories = salatService.CountCalories();
            salatService.SortIngredientsByCalories();
            
            Console.WriteLine(salatService.ToString());
            
        }
    }
}
