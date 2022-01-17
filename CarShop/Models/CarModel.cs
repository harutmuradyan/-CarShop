using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }

        public string CarModelName { get; set; }

       

        public Company Company { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
