using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Entities;
using VegetableSalad.DAL.Interfaces;

namespace VegetableSalad.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private string path;
        private VegetableRepository vegetableRepository;

        public UnitOfWork(string _path)
        {
            path = _path;
        }
        public IVegetableRepository<VegetableEntity> Vegetables
        {
            get
            {
                if (vegetableRepository == null)
                    vegetableRepository = new VegetableRepository(path);
                return vegetableRepository;
            }
        }
    }
}
