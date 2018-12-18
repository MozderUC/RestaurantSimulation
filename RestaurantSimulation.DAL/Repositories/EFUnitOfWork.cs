using RestaurantSimulation.DAL.EF;
using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Repositories
{
    public class EFUnitOfWork : IDisposable, IEFUnitOfWork
    {
        private RestaurantContext Db;
        private MenuRepository MenuRepository;
        private VegetableReposirory VegetableReposirory;
        private VegetableStorageRepository VegetableStorageRepository;
        private GuestbookRepository GuestbookRepository;

        public EFUnitOfWork()
        {
            Db = new RestaurantContext();            
        }

        public IRepository<Menu> Menu
        {
            get
            {
                if (MenuRepository == null)
                    MenuRepository = new MenuRepository(Db);
                return MenuRepository;
            }
        }

        public IRepository<Vegetable> Vegetables
        {
            get
            {
                if (VegetableReposirory == null)
                    VegetableReposirory = new VegetableReposirory(Db);
                return VegetableReposirory;
            }
        }

        public IRepository<VegetableStorage> VegetableStorage
        {
            get
            {
                if (VegetableStorageRepository == null)
                    VegetableStorageRepository = new VegetableStorageRepository(Db);
                return VegetableStorageRepository;
            }
        }

        public IRepository<Guestbook> Guestbook
        {
            get
            {
                if (GuestbookRepository == null)
                    GuestbookRepository = new GuestbookRepository(Db);
                return GuestbookRepository;
            }
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
