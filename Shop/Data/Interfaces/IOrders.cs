using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IOrders
    {
        void CreateOrder(Order order);
    }
}
