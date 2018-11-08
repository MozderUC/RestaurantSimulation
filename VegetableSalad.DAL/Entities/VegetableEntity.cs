using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.DAL.Entities
{
    public class VegetableEntity
    {
        public string Name { get; set; }
        public float Proteins { get; set; }
        public float Carbohydrates { get; set; }
        public float Fats { get; set; }
        public float Calories { get; set; }
        public float AscorbicAcid { get; set; }
    }
}
