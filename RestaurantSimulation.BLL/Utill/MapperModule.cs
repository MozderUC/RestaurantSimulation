
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
        public static Models.Vegetable EFVegetable_To_Vegetable(Vegetable vegetables)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vegetable, Models.Vegetable>()).CreateMapper();
            Models.Vegetable Vegetables = mapper.Map<Vegetable, Models.Vegetable>(vegetables);

            return Vegetables;

        }
    }
}
