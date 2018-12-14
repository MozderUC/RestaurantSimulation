using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
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
