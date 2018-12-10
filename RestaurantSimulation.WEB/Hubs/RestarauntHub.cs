using Microsoft.AspNet.SignalR;

namespace RestaurantSimulation.WEB.Hubs
{
    public class RestarauntHub : Hub
    {
        public void AddNewMessageToPage(string message, int tableNumber)
        {
            Clients.All.displayMessage(message, tableNumber);
        }
    }
}