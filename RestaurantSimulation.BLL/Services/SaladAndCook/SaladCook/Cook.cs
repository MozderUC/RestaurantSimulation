using RestaurantSimulation.BLL.Models;

namespace RestaurantSimulation.BLL.Services.SaladAndCook.SaladCook
{
    public abstract class Cook
    {
        public VegetableSalad VegetableSalad { get; private set; }
        public VegetableStorageService VegetableStorage { get; set; }

        protected Cook()
        {
            VegetableSalad = new VegetableSalad();
            VegetableStorage = new VegetableStorageService();
        }
        
        public abstract VegetableSalad MakeSalad(SaladOrder.SaladOrder order);
    }
}
