using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder
{
    public class VinaigretteSaladOrder : SaladOrder
    {
        public override string Dish { get; set; } = "VinaigretteSalad";
        public override int Cost { get; set; } = 34;

        public override VegetableSalad OrderSalad(IRestaurantChief p)
        {
            return p.OrderSalad(this);
        }
    }
}
