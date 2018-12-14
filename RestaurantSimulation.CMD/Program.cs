using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder;

namespace RestaurantSimulation.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            ClientsRegistrationService clientsRegistrationService = new ClientsRegistrationService();

            // Client registration
            ClientsService clientsService1 = clientsRegistrationService.AddClients(2);
            ClientsService clientsService2 = clientsRegistrationService.AddClients(3);
            ClientsService clientsService3 = clientsRegistrationService.AddClients(4);
            ClientsService clientsService4 = clientsRegistrationService.AddClients(1);


            // Clients get the menu
            var Menu = clientsService1.GetMenu();
            foreach(var salat in Menu)
            {
                Console.WriteLine("Salat name: {0} || Cost: {1}",salat.Name,salat.Cost);
            }

            // Clients make order
            List<VegetableSalad> order1 = clientsService1.MakeOrder(new List<SaladOrder> {new VinaigretteSaladOrder(), new GalaxySaladOrder()});
            List<VegetableSalad> order2 = clientsService2.MakeOrder(new List<SaladOrder> { new VinaigretteSaladOrder(), new GalaxySaladOrder() });
            List<VegetableSalad> order3 = clientsService3.MakeOrder(new List<SaladOrder> {new GalaxySaladOrder() });
            List<VegetableSalad> order4 = clientsService4.MakeOrder(new List<SaladOrder> { new VinaigretteSaladOrder(), new GalaxySaladOrder() });

            // Get Sum of the order
            //float BillSum1 = clientsService1.GetBill();
            //float BillSum2 = clientsService2.GetBill();
            //float BillSum3 = clientsService3.GetBill();
            //float BillSum4 = clientsService4.GetBill();
            //Console.WriteLine(BillSum1);
            //Console.WriteLine(BillSum2);
            //Console.WriteLine(BillSum3);
            //Console.WriteLine(BillSum4);

            // LeaveFeedback
            clientsService1.LeaveFeedback("It's restauraunt have big potential", "Dima");
            
        }
    }
}
