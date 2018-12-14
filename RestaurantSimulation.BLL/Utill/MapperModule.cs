
using AutoMapper;
using RestaurantSimulation.DAL.Entities;

namespace RestaurantSimulation.BLL.Utill
{
    public class MapperModule
    {
        public static Models.Vegetable EFVegetable_To_Vegetable(Vegetable eFVegetables)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vegetable, Models.Vegetable>()).CreateMapper();
            var vegetables = mapper.Map<Vegetable, Models.Vegetable>(eFVegetables);

            return vegetables;

        }
    }
}
