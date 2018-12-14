using RestaurantSimulation.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services
{
    public abstract class SaladOrder
    {
        public abstract string Dish { get; set; }
        public abstract int Cost { get; set; }
        public abstract VegetableSalad OrderSalad(IRestaurantChief p);
    }
}
