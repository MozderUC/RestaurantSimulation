using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IVegetableRepository<VegetableEntity> Vegetables { get; }
    }
}
