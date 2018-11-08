using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create sourse Json file 
         
            List<VegetableEntity> vegetables = new List<VegetableEntity>
            {
                new VegetableEntity{Name = "Tomato",Proteins = 12,Carbohydrates = 44,Fats = 11,Calories = 12,AscorbicAcid = 12 },
                new VegetableEntity{Name = "Cucumber",Proteins = 12,Carbohydrates = 44,Fats = 11,Calories = 12,AscorbicAcid = 12 },
                new VegetableEntity{Name = "Cabbage",Proteins = 12,Carbohydrates = 44,Fats = 11,Calories = 12,AscorbicAcid = 12 }
            };

            string json = JsonConvert.SerializeObject(vegetables, Formatting.Indented);
            
            
            string Path = @"vegetables.txt";

            try
            {          
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }
    }
}
