using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Entities
{
    public class Guestbook
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
    }
}
