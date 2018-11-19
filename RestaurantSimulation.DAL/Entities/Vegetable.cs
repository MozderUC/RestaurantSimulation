using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.DAL.Entities
{
    public class Vegetable
    {
        [Key]
        [ForeignKey("VegetableStorage")]
        public int ID { get; set; }

        public string Name { get; set; }
        public float Proteins { get; set; }
        public float Carbohydrates { get; set; }
        public float Fats { get; set; }
        public float Calories { get; set; }

        public VegetableStorage VegetableStorage { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
