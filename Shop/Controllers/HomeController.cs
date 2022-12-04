using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICars _carRep;

        public HomeController(ICars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel { FavCars = _carRep.FavCars};

            return View(homeCars);
        }
    }
}
