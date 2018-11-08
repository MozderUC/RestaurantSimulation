using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.DAL.Interfaces
{
    public interface IVegetableRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
