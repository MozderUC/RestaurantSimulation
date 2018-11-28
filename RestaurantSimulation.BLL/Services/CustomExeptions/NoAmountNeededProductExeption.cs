using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class NoAmountNeededProduct : Exception
    {
        public NoAmountNeededProduct(string message)
        : base(message)
        { }
    }
}
