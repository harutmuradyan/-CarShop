using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string User { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупателя
        public string ContactPhone { get; set; } // контактный телефон покупателя

        public string Comment { get; set; }

        public int CarId { get; set; } // ссылка на связанную модель Phone
        public Car Car { get; set; }
    }
}
