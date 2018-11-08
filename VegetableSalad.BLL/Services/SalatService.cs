using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Interfaces;
using VegetableSalad.DAL.Repositories;
using VegetableSalad.DAL.Entities;
using VegetableSalad.BLL.Models;
using VegetableSalad.BLL.Utill;

namespace VegetableSalad.BLL.Services
{
    public class SalatService
    {
        private IVegetableRepository<VegetableEntity> VegetableRepository { get; set; }
        private List<Food> Food { get; set; }
        
        public SalatService(IVegetableRepository<DAL.Entities.VegetableEntity> _vegetable)
        {
            VegetableRepository = _vegetable;

            IEnumerable<VegetableEntity> Vegetables = VegetableRepository.GetAll();
            Food = new List<Food>();
            Food.AddRange(MapperModule.VegetableEntity_To_Vegetable(Vegetables));
            Console.WriteLine("Hellow");
            


            
        }



    }
}
