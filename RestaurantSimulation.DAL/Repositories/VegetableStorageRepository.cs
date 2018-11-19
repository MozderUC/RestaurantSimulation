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
    public class VegetableStorageRepository : IRepository<VegetableStorage>
    {
        private RestaurantContext db;

        public VegetableStorageRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<VegetableStorage> GetAll()
        {
            return db.VegetableStorages;
        }

        public VegetableStorage Get(int id)
        {
            return db.VegetableStorages.Find(id);
        }

        public void Create(VegetableStorage VegetableStorage)
        {
            db.VegetableStorages.Add(VegetableStorage);
        }

        public void Update(VegetableStorage VegetableStorage)
        {
            db.Entry(VegetableStorage).State = EntityState.Modified;
        }

        public IEnumerable<VegetableStorage> Find(Func<VegetableStorage, Boolean> predicate)
        {
            return db.VegetableStorages.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            VegetableStorage VegetableStorage = db.VegetableStorages.Find(id);
            if (VegetableStorage != null)
                db.VegetableStorages.Remove(VegetableStorage);
        }
    }
}
