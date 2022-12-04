using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : ICars
    {
        private readonly AppDbContext appDbContext;

        public CarRepository(AppDbContext appDbContext) => this.appDbContext = appDbContext;

        public IEnumerable<Car> AllCars => appDbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> FavCars => appDbContext.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetCarObject(int carID) => appDbContext.Cars.FirstOrDefault(p => p.Id == carID);
    }
}
