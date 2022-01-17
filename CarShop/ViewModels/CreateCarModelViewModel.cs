using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CreateCarModelViewModel
    {
        public int CarModelId { get; set; }

        public string CarModelName { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
