using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantSimulation.WEB.Models
{
    public class ClientServiceViewModel
    {
        public int TableNumber { get; set; }
        public List<SaladOrder> TableOrder { get; set; }
        public int Bill { get; set; }
    }
}