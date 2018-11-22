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
    public class GuestbookRepository : IRepository<Guestbook>
    {
        private RestaurantContext db;

        public GuestbookRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Guestbook> GetAll()
        {
            return db.Guestbook;
        }

        public Guestbook Get(int id)
        {
            return db.Guestbook.Find(id);
        }

        public void Create(Guestbook Guestbook)
        {
            db.Guestbook.Add(Guestbook);
        }

        public void Update(Guestbook Guestbook)
        {
            db.Entry(Guestbook).State = EntityState.Modified;
        }

        public IEnumerable<Guestbook> Find(Func<Guestbook, Boolean> predicate)
        {
            return db.Guestbook.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Guestbook Guestbook = db.Guestbook.Find(id);
            if (Guestbook != null)
                db.Guestbook.Remove(Guestbook);
        }
    }
}
