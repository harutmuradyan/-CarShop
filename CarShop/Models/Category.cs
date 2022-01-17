using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Category
    {
        public int CategoryId {get; set;}

        public string CategoryName { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();

    }
}
