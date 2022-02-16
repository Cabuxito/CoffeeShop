using ServiceLayer.Services.UserService.Models;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// Create user, check password and write user to database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword1"></param>
        /// <param name="userPassword2"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        bool AddUser(string userName, string userPassword1, string userPassword2, 
            string firstName, string lastName, string email, int phoneNumber, bool createSucces);
        public string LoginUser(string userName, string password);

        //TODO: skal fikses ""
        public List<UserModels> GetUserInfo();
        public List<OrdersModels> GetOrders();
        public List<CoffeeModels> GetCoffee();
        public List<CakeModels> GetCake();
        public ProductModels GetProductById(int Id);
        public void BuyProduct(DateTime date, int ProductId, int Amount, string ProductName, int Price, string OrderNote);
        public OrdersModels GetLastOrder();
        public string CoffeUpdate(int productID, string productName, string productDescription, int productPrice);
        public string DeleteOrderById(int OrdersID);
        public string DeleteProductById(int ProductID);
    }
}
