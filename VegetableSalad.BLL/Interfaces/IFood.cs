using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Interfaces
{
    public interface IFood
    {
        string Name { get; set; }
        float Proteins { get; set; }
        float Carbohydrates { get; set; }
        float Fats { get; set; }
        float Calories { get; set; }       
    }
}
