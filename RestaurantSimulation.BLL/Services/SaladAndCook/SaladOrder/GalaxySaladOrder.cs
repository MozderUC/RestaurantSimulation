using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder
{
    public class GalaxySaladOrder : SaladOrder
    {
        public override string Dish { get; set; } = "GalaxySalad";
        public override int Cost { get; set; } = 12;

        public override VegetableSalad OrderSalad(IRestaurantChief p)
        {
            return p.OrderSalad(this);
        }
    }
}
