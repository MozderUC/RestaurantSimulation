using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Interfaces
{
    public interface ISalatService
    {
        void SetSaladName(string saladName);
        bool AddIngredient(string IngredientName, int amount);
        float CountCalories();
        bool SortIngredientsByCalories();
        Models.VegetableSalad GetSalatObject();
        string ToString();
    }
}
