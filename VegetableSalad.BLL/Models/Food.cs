using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Interfaces;

namespace VegetableSalad.BLL.Models
{
    public class Food : IFood
    {
        public string Name { get; set; }
        public float Proteins { get; set; }
        public float Carbohydrates { get ; set ; }
        public float Fats { get; set; }
        public float Calories { get ; set ; }
    }
}
