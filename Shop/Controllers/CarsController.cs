using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _allCars;
        private readonly ICategories _allCategories;

        public CarsController(ICars allCars, ICategories carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.AllCars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.AllCars.Where(i => i.Category.categoryName == "Электромобили").OrderBy(i => i.Id);
                    currCategory = "Электромобили";
                }
                else
                if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.AllCars.Where(i => i.Category.categoryName == "Классические автомобили").OrderBy(i => i.Id);
                    currCategory = "Классические автомобили";
                }
            }

            var carObj = new CarsListViewModel { AllCars = cars, CurrCategory = currCategory };

            ViewBag.Title = "Стрница с автомобилями";

            return View(carObj);
        }
    }
}
