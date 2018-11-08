using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Interfaces;
using VegetableSalad.DAL.Repositories;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.BLL.Utill
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IVegetableRepository<VegetableEntity>>().To<VegetableRepository>();
        }
    }
}
