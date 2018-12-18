using System;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class NoAmountNeededProductException : Exception
    {
        public NoAmountNeededProductException(string message)
        : base(message)
        { }
    }
}
