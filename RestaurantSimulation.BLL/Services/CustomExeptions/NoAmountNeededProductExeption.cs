using System;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class NoAmountNeededProduct : Exception
    {
        public NoAmountNeededProduct(string message)
        : base(message)
        { }
    }
}
