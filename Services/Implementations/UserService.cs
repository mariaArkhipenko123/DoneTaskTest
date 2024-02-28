using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
       
            private readonly List<User> userService;

            public UserService(List<User> userService)
            {
                this.userService = userService;
            }

            public Task<User> GetUser()
        {
            if (userService == null || !userService.Any())
            {
                return null;
            }

            // Просто вернуть первый заказ из списка заказов
            return Task.FromResult(userService.First());
        }

        public Task<List<User>> GetUsers()
        {
            if (userService == null || !userService.Any())
            {
                return null;
            }

            // Вернуть все заказы из списка заказов
            return Task.FromResult(userService); ;
        }

      
        public User GetUserWithMostOrders()
        {
            if (userService == null || !userService.Any())
            {
                return null;
            }

            User userWithMostOrders = userService.OrderByDescending(u => u.Orders.Count).First();
            return userWithMostOrders;  
        }

        public List<User> GetUsersWithInactiveStatus()
        {
            if (userService == null || !userService.Any())
            {
                return new List<User>();
            }

            List<User> usersWithInactiveStatus = userService.Where(u => u.Status == UserStatus.Inactive).ToList();
            return usersWithInactiveStatus;
        }


    }
}
