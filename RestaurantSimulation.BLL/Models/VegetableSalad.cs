namespace RestaurantSimulation.BLL.Models
{
    public class VegetableSalad
    {
        public VegetableCollection Ingredients { set; get; }
        public string Name { get; set; }
        public VegetableSalad()
        {
            Ingredients = new VegetableCollection();
        }
    }
}
