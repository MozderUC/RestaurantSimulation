using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Interfaces;
using VegetableSalad.BLL.Services;

namespace VegetableSalad.CMD.Utill
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISalatService>().To<SalatService>();
        }
    }
}
