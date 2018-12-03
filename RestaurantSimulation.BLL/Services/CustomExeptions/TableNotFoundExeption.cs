using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class TableNotFoundExeption : Exception
    {
        public TableNotFoundExeption(string message)
        : base(message)
        { }
    }
}
