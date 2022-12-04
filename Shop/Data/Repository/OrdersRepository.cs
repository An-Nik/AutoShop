using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContext appDbContext, ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContext.Orders.Add(order);

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };

                appDbContext.OrderDetails.Add(orderDetail);
            }

            appDbContext.SaveChanges();
        }
    }
}
