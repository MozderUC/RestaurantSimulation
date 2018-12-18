using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.DAL.Interfaces;

namespace RestaurantSimulation.DAL.Repositories
{
    public interface IEFUnitOfWork
    {
        IRepository<Menu> Menu { get; }
        IRepository<Vegetable> Vegetables { get; }
        IRepository<VegetableStorage> VegetableStorage { get; }
        IRepository<Guestbook> Guestbook { get; }
        void Save();
        void Dispose(bool disposing);
        void Dispose();
    }
}