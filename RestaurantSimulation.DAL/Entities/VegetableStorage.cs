using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Entities
{
    public class VegetableStorage
    {
        public int ID { get; set; }

        public float VegetableStock { get; set; }

        public Vegetable Vegetable { get; set; }
    }
}
