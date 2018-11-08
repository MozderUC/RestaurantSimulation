using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableSalad.DAL.Entities;

namespace VegetableSalad.DAL.Repositories
{
    public class VegetableRepository : Interfaces.IVegetableRepository<VegetableEntity>
    {

        private readonly string path = @"vegetables.txt";

        public IEnumerable<VegetableEntity> GetAll()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string text = sr.ReadToEnd();
                    IEnumerable<VegetableEntity> vegetables = JsonConvert.DeserializeObject<List<VegetableEntity>>(text);
                    return vegetables;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
