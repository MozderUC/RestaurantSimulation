using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services;
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

            ClientsRegistrationService clientsRegistrationService = new ClientsRegistrationService();

            // Client registration
            ClientsService clientsService = clientsRegistrationService.AddClients(2);


            // Clients get the menu
            var Menu = clientsService.GetMenu();
            foreach(var salat in Menu)
            {
                Console.WriteLine("Salat name: {0} || Cost: {1}",salat.Name,salat.Cost);
            }

            // Clients make order
            List<VegetableSalad> order = clientsService.MakeOrder(new List<SaladOrder> {new VinaigretteSaladOrder(), new GalaxySaladOrder()});          

            /// Vegetable Collection Tests
            //Vegetable veg = new Vegetable() { Name = "Ogyrec", Calories = 12, Fats = 12, Proteins = 12, AscorbicAcid = 12, Carbohydrates = 12, Weight = 34};
            //Vegetable veg1 = new Vegetable() { Name = "Pomidor", Calories = 12, Fats = 12, Proteins = 12, AscorbicAcid = 12, Carbohydrates = 12, Weight = 34 };
            //VegetableCollection sett = new VegetableCollection();
            //sett.Add(veg);
            //sett.Add(veg);
            //sett.Add(veg1);            
        }
    }
}
