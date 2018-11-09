using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.BLL.Services;
using VegetableSalad.DAL.Interfaces;
using VegetableSalad.DAL.Repositories;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var mailSender = kernel.Get<IVegetableRepository<VegetableEntity>>();

            SalatService vegetableService = new SalatService(mailSender);

            vegetableService.AddIngredient("Tomato",12);
            vegetableService.AddIngredient("Cucumber", 12);
            vegetableService.AddIngredient("Cabbage", 12);
            vegetableService.AddIngredient("Tomato", 28);


        }
    }
}
