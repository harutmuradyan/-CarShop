using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class EditCarViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }

        public string Color { get; set; } //Գույնը

        public string Engine { get; set; } // Բենզին

        public string SteeringWheel { get; set; } //Ղեկը

        public string Transmission { get; set; }//Փոխանցման տուփը

        public string Modification { get; set; } //Մոդիֆիկացիան

        public string Body { get; set; } //Թափքը

        public int Mileage { get; set; } //Ավտոմեքենայի վազքը
    }
}
