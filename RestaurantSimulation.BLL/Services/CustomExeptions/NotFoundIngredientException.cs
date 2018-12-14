using System;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class NotFoundIngredientException : Exception
    {
        public NotFoundIngredientException(string message)
        : base(message)
        { }
    }
}
