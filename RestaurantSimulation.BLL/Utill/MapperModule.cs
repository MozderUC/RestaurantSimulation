
using AutoMapper;
using RestaurantSimulation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Utill
{
    public class MapperModule
    {
        public static IEnumerable<Models.Vegetable> EFVegetable_To_Vegetable(IEnumerable<Vegetable> vegetables)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vegetable, Models.Vegetable>()).CreateMapper();
            IEnumerable<Models.Vegetable> Vegetables = mapper.Map<IEnumerable<Vegetable>, IEnumerable<Models.Vegetable>>(vegetables);

            return Vegetables;

        }
    }
}
