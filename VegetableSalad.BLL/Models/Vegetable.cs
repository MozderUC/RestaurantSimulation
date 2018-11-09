using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Interfaces;

namespace VegetableSalad.BLL.Models
{
    public class Vegetable : Food, IAscorbicAcid
    {
        public float AscorbicAcid { get ; set ; }
    }
}
