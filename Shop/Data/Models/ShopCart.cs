using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContext appDbContext;

        public ShopCart(AppDbContext appDbContext) => this.appDbContext = appDbContext;

        public string ShopCartID { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string shopCartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", shopCartID);

            return new ShopCart(context) { ShopCartID = shopCartID };
        }


        public void AddToCart(Car car)
        {
            appDbContext.ShopCarItems.Add(new ShopCartItem
            {
                ShopCartID = ShopCartID,
                Car = car,
                Price = car.Price
            });

            appDbContext.SaveChanges();
        }


        public List<ShopCartItem> GetShopItems()
        {
            return appDbContext.ShopCarItems.Where(c => c.ShopCartID == ShopCartID).Include(s => s.Car).ToList();

        }
    }
}
