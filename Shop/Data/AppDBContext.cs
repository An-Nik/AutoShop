using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<ShopCartItem> ShopCarItems { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }

    }
}
