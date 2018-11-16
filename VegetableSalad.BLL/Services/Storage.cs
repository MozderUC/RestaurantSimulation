using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Models;
using VegetableSalad.DAL.Interfaces;

namespace VegetableSalad.BLL.Services
{
    public class Storage
    {      
        public Dictionary<int, Vegetable> VegetablesStorage { get; private set; }

        public Storage()
        {

        }
        public Storage(Dictionary<int, Vegetable> vegetablesStorage)
        {
            VegetablesStorage = vegetablesStorage;
        }

        public Tuple<int, Vegetable> TakeProduct (string ProductName, int Weight)
        {

        }

        public void AddProduct(Tuple<int, Vegetable> product)
        {

        }

    }
}
