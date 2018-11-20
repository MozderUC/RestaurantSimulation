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
    public class MenuRepository : IRepository<Menu>
    {
        private RestaurantContext db;

        public MenuRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Menu> GetAll()
        {
            return db.Menu;
        }

        public Menu Get(int id)
        {
            return db.Menu.Find(id);
        }

        public void Create(Menu menu)
        {
            db.Menu.Add(menu);
        }

        public void Update(Menu menu)
        {
            db.Entry(menu).State = EntityState.Modified;
        }

        public IEnumerable<Menu> Find(Func<Menu, Boolean> predicate)
        {
            return db.Menu.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Menu movie = db.Menu.Find(id);
            if (movie != null)
                db.Menu.Remove(movie);
        }
    }
}
