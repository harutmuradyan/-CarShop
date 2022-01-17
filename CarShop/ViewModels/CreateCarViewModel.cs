using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CreateCarViewModel
    {
        public string Name { get; set; }
        //public string Company { get; set; }
        public int Price { get; set; }
        //public string CarModel { get; set; }

        public string Color { get; set; } //Գույնը

        public string Engine { get; set; } // Բենզին

        public string SteeringWheel { get; set; } //Ղեկը

        public string Transmission { get; set; }//Փոխանցման տուփը

        public string Modification { get; set; } //Մոդիֆիկացիան

        public string Body { get; set; } //Թափքը

        public int Mileage { get; set; } //Ավտոմեքենայի վազքը

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public int CarModelId { get; set; }

    }
}
