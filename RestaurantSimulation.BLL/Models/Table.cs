using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Models
{
    public class Table
    {
        public int TableNumber { get; set; }
        public int SeatcCount { get; set; }
        public bool Reserved { get; set; }
    }
}
