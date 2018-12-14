using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladOrder
{
    public abstract class SaladOrder
    {
        public abstract string Dish { get; set; }
        public abstract int Cost { get; set; }
        public abstract VegetableSalad OrderSalad(IRestaurantChief p);
    }
}
