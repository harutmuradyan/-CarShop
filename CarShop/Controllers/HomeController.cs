using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsContext db;
        public HomeController(CarsContext context)
        {
            db = context;

        }


        public IActionResult Index()
        {
            ViewBag.categorys = db.Categorys.ToList();
            ViewBag.companys = db.Companys.ToList();
            ViewBag.models = db.Models.ToList();
            List<Car> carlist = db.Cars.Include(item => item.Category).ToList();
            return View(carlist);
        }


        public IActionResult Products()
        {
            return View(db.Cars.ToList());
        }

        [Authorize(Roles = "user")]
        public IActionResult Buy()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpGet("{id}")]
        public IActionResult Presentation(int id)
        {
            var cars = db.Cars.FirstOrDefault(p => p.CarId == id);
            return View(cars);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.CarId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
