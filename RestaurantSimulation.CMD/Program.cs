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

            // Get Sum of the order
            float BillSum = clientsService.GetBill();

            // LeaveFeedback
            clientsService.LeaveFeedback("It's restauraunt have big potential", "Dima");
            
        }
    }
}
