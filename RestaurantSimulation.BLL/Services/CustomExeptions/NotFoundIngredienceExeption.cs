using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public class NotFoundIngredienceExeption : Exception
    {
        public NotFoundIngredienceExeption(string message)
        : base(message)
        { }
    }
}
