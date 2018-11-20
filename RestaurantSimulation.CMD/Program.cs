using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            


            Vegetable veg = new Vegetable() { Name = "Ogyrec", Calories = 12, Fats = 12, Proteins = 12, AscorbicAcid = 12, Carbohydrates = 12, Weight = 34};
            Vegetable veg1 = new Vegetable() { Name = "Pomidor", Calories = 12, Fats = 12, Proteins = 12, AscorbicAcid = 12, Carbohydrates = 12, Weight = 34 };
            VegetableCollection sett = new VegetableCollection();
            sett.Add(veg);
            sett.Add(veg);
            sett.Add(veg1);

            var list = sett.GetList();

            Console.WriteLine();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
