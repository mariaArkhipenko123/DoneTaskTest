using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> orderService;

        public OrderService(List<Order> orderService)
        {
            this.orderService = orderService;
        }
        public Task<Order> GetOrder()
        {
            if (orderService == null || !orderService.Any())
            {
                return null;
            }

            // Просто вернуть первый заказ из списка заказов
            return Task.FromResult(orderService.First());
        }

        public Task<List<Order>> GetOrders()
        {
            if (orderService == null || !orderService.Any())
            {
                return null;
            }

            // Вернуть все заказы из списка заказов
            return Task.FromResult(orderService);
        }
        public Task<Order> GetOrderWithHighestTotalAmount()
        {
            if (orderService == null || !orderService.Any())
            {
                return null;
            }

            Order orderWithHighestTotalAmount = orderService.OrderByDescending(o => o.Price).First();
            return Task.FromResult(orderWithHighestTotalAmount);
        }

        public Task<List<Order>> GetOrdersWithQuantityGreaterThan(int quantity)
        {
            if (orderService == null || !orderService.Any())
            {
                return null;    
            }
            List<Order> ordersWithQuantityGreaterThan = orderService.Where(o => o.Quantity > quantity).ToList();
            return Task.FromResult(ordersWithQuantityGreaterThan);
        }
    }
}
