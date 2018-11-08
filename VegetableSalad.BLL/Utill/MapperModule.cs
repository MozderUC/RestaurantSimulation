using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using VegetableSalad.BLL.Models;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.BLL.Utill
{
    class MapperModule
    {
        public static IEnumerable<Vegetable> VegetableEntity_To_Vegetable(IEnumerable<VegetableEntity> vegetableEntities)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VegetableEntity, Vegetable>()).CreateMapper();
            Vegetable vegetable = new Vegetable();
            IEnumerable<Vegetable> vegetables = mapper.Map<IEnumerable<VegetableEntity>, IEnumerable<Vegetable>>(vegetableEntities);

            return vegetables;
        }
    }
}
