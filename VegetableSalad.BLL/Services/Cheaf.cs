using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.BLL.Services
{
    public abstract class Cheaf
    {
        public Models.VegetableSalad VegetableSalad { get; private set; }

        public void CreateVegetableSalad()
        {
            VegetableSalad = new Models.VegetableSalad();
        }
        public abstract void MakeSalad();       
    }
}
