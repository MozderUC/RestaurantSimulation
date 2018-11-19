using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Entities
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }

        public virtual ICollection<Vegetable> Vegetables { get; set; }
    }
}
