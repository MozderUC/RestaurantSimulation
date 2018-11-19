﻿using RestaurantSimulation.DAL.EF;
using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Repositories
{
    public class EFUnitOfWork : IDisposable
    {
        private RestaurantContext Db;
        private MenuRepository MenuRepository;
        private VegetableReposirory VegetableReposirory;
        private VegetableStorageRepository VegetableStorageRepository;

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
