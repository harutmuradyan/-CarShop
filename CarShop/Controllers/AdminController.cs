using CarShop.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly CarsContext _carContext;

        public AdminController(CarsContext carsContext)
        {
            _carContext = carsContext;
        }
        

        //adminic avtomeqenayi avelacum ej@
        public IActionResult CreateCar()
        {
            ViewBag.categorys = _carContext.Categorys.ToList();
            ViewBag.companys = _carContext.Companys.ToList();
            ViewBag.models = _carContext.Models.ToList();
            return View();
        }

        //Adminic bolor avtomeqenaneri ditum ej@
        public IActionResult Index()
        {
            List<Car> carlist = _carContext.Cars.Include(item => item.Category).ToList();
            return View(carlist);
        }

        //adminic categoryayi avelacum ej@
        public IActionResult CreateCategory() => View();

        //adminic categoryai ditum ej@
        public IActionResult CategoryView() => View(_carContext.Categorys.ToList());

        //adminic companyii avelacum ej@
        public IActionResult CreateCompany() => View();

        //adminic companii ditum ej@
        public IActionResult CompanyView() => View(_carContext.Companys.ToList());

        //adminic avtomeqenayi modeli avelacum ej@
        public IActionResult CreateCarModel()
        {
            ViewBag.companys = _carContext.Companys.ToList();
            return View();
        }
        
        //adminic avtomeqenayi modeli ditum ej@
        public IActionResult CarModelView() => View(_carContext.Models.ToList());

        //adminic patverneri ditum ej@
        public IActionResult Order()
        {
            List<Order> carlist = _carContext.Orders.ToList();
            return View(carlist);
        }


        [HttpPost]
        public IActionResult CreateCar(CreateCarViewModel carModel)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    Name = carModel.Name,
                    Price = carModel.Price,
                    Color = carModel.Color,
                    Engine = carModel.Engine,
                    SteeringWheel = carModel.SteeringWheel,
                    Transmission = carModel.Transmission,
                    Modification = carModel.Modification,
                    Body = carModel.Body,
                    Mileage = carModel.Mileage,
                    Category = _carContext.Categorys.FirstOrDefault(item => item.CategoryId == carModel.CategoryId),
                    Company = _carContext.Companys.FirstOrDefault(item => item.CompanyId == carModel.CompanyId),
                    CarModel = _carContext.Models.FirstOrDefault(item => item.CarModelId == carModel.CarModelId)
                };
                _carContext.Cars.Add(car);
                _carContext.SaveChanges();
                return RedirectPermanent("/admin/index");
            }
            return View(carModel);
        }

        public IActionResult EditCar(string id)
        {
            Car car = _carContext.Cars.FirstOrDefault(item => item.CarId.ToString() == id);
            if (car == null)
            {
                return NotFound();
            }
            EditCarViewModel model = new EditCarViewModel { Name = car.Name,/* Company = car.Company,*/ Price = car.Price,/* Model = car.Model */};
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCar(EditCarViewModel carModel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carContext.Cars.FirstOrDefault(item => item.CarId.ToString() == carModel.Id);
                if (car != null)
                {
                    car.Name = carModel.Name;
                    car.Price = carModel.Price;
                    car.Color = carModel.Color;
                    car.Engine = carModel.Engine;
                    car.SteeringWheel = carModel.SteeringWheel;
                    car.Transmission = carModel.Transmission;
                    car.Modification = carModel.Modification;
                    car.Body = carModel.Body;
                    car.Mileage = carModel.Mileage;

                    _carContext.Cars.Update(car);

                    _carContext.SaveChanges();
                    return RedirectPermanent("/admin/index");


                }
            }
            return View(carModel);
        }

        [HttpPost]
        public ActionResult DeleteCar(string id)
        {
            Car car = _carContext.Cars.FirstOrDefault(item => item.CarId.ToString() == id);
            if (car != null)
            {
                _carContext.Cars.Remove(car);
                _carContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }





        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    CategoryName = categoryModel.CategoryName
                };
                _carContext.Categorys.Add(category);
                _carContext.SaveChanges();
                return RedirectPermanent("/admin/index");
            }
            return View(categoryModel);
        }

        public IActionResult EditCategory(string id)
        {
            Category category = _carContext.Categorys.FirstOrDefault(item => item.CategoryId.ToString() == id);
            if (category == null)
            {
                return NotFound();
            }
            EditCategoryViewModel model = new EditCategoryViewModel { CategoryName = category.CategoryName };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category category = _carContext.Categorys.FirstOrDefault(item => item.CategoryId.ToString() == categoryModel.CategoryId);
                if (category != null)
                {
                    category.CategoryName = categoryModel.CategoryName;

                    _carContext.Categorys.Update(category);

                    _carContext.SaveChanges();
                    return RedirectPermanent("/admin/index");


                }
            }
            return View(categoryModel);
        }

        [HttpPost]
        public ActionResult DeleteCategory(string id)
        {
            Category category = _carContext.Categorys.FirstOrDefault(item => item.CategoryId.ToString() == id);
            if (category != null)
            {
                _carContext.Categorys.Remove(category);
                _carContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyViewModel companyModel)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company
                {
                    CompanyName = companyModel.CompanyName
                };
                _carContext.Companys.Add(company);
                _carContext.SaveChanges();
                return RedirectPermanent("/admin/index");
            }
            return View(companyModel);
        }

        public IActionResult EditCompany(string id)
        {
            Company company = _carContext.Companys.FirstOrDefault(item => item.CompanyId.ToString() == id);
            if (company == null)
            {
                return NotFound();
            }
            EditCompanyViewModel model = new EditCompanyViewModel { CompanyName = company.CompanyName };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCompany(EditCompanyViewModel companyModel)
        {
            if (ModelState.IsValid)
            {
                Company company = _carContext.Companys.FirstOrDefault(item => item.CompanyId.ToString() == companyModel.CompanyId);
                if (company != null)
                {
                    company.CompanyName = companyModel.CompanyName;

                    _carContext.Companys.Update(company);

                    _carContext.SaveChanges();
                    return RedirectPermanent("/admin/index");


                }
            }
            return View(companyModel);
        }

        [HttpPost]
        public ActionResult DeleteCompany(string id)
        {
            Company company = _carContext.Companys.FirstOrDefault(item => item.CompanyId.ToString() == id);
            if (company != null)
            {
                _carContext.Companys.Remove(company);
                _carContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }





        [HttpPost]
        public IActionResult CreateCarModel(CreateCarModelViewModel carmodsModel)
        {
            if (ModelState.IsValid)
            {
                CarModel carModel = new CarModel
                {
                    CarModelName = carmodsModel.CarModelName,
                    Company = _carContext.Companys.FirstOrDefault(item => item.CompanyId == carmodsModel.CompanyId)
                };
                _carContext.Models.Add(carModel);
                _carContext.SaveChanges();
                return RedirectPermanent("/admin/index");
            }
            return View(carmodsModel);
        }

        public IActionResult EditCarModel(string id)
        {
            CarModel carModel = _carContext.Models.FirstOrDefault(item => item.CarModelId.ToString() == id);
            if (carModel == null)
            {
                return NotFound();
            }
            EditCarModelViewModel model = new EditCarModelViewModel { CarModelName = carModel.CarModelName };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCarModel(EditCarModelViewModel carmodsModel)
        {
            if (ModelState.IsValid)
            {
                CarModel carModel = _carContext.Models.FirstOrDefault(item => item.CarModelId.ToString() == carmodsModel.CarModelId);
                if (carModel != null)
                {
                    carModel.CarModelName = carmodsModel.CarModelName;

                    _carContext.Models.Update(carModel);

                    _carContext.SaveChanges();
                    return RedirectPermanent("/admin/index");


                }
            }
            return View(carmodsModel);
        }

        [HttpPost]
        public ActionResult DeleteCarModel(string id)
        {
            CarModel carModel = _carContext.Models.FirstOrDefault(item => item.CarModelId.ToString() == id);
            if (carModel != null)
            {
                _carContext.Models.Remove(carModel);
                _carContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }


    }
}


