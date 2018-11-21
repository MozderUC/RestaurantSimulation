using RestaurantSimulation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<VegetableStorage> VegetableStorages { get; set; }
        
        public RestaurantContext() : base("RestaurantSimulation")
        {
        }
        
    }
}
