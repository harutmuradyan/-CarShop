using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
