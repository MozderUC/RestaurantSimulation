using RestaurantSimulation.DAL.EF;
using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Repositories
{
    public class VegetableReposirory : IRepository<Vegetable>
    {
        private RestaurantContext db;

        public VegetableReposirory(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Vegetable> GetAll()
        {
            return db.Vegetables;
        }

        public Vegetable Get(int id)
        {
            return db.Vegetables.Find(id);
        }

        public void Create(Vegetable Vegetable)
        {
            db.Vegetables.Add(Vegetable);
        }

        public void Update(Vegetable Vegetable)
        {
            db.Entry(Vegetable).State = EntityState.Modified;
        }

        public IEnumerable<Vegetable> Find(Func<Vegetable, Boolean> predicate)
        {
            return db.Vegetables.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Vegetable Vegetable = db.Vegetables.Find(id);
            if (Vegetable != null)
                db.Vegetables.Remove(Vegetable);
        }
    }
}
