using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserService.Models
{
    public class UserModels
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int phoneNumber { get; set; }
    }

    public class OrdersModels 
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime OrderDato { get; set; }
        public int TotalOrder { get; set; }
        public string OrderNote { get; set; }
    }
    
    public class CoffeeModels 
    {
        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public string CoffeeDescription { get; set; }
        public int CoffeePrice { get; set; }
        public int CoffeeQuantity { get; set; }
        public string PathToImg { get; set; }
        public string Type { get; set; }
    }

    public class CakeModels 
    {
        public int CakeId { get; set; }
        public string CakeName { get; set; }
        public string CakeDescription { get; set; }
        public int CakePrice { get; set; }
        public int CakeQuantity { get; set; }
        public string PathToImg { get; set; }
        public string Type { get; set; }
    }

    public class ProductModels
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Amount { get; set; }
        public string OrderDate { get; set; }
    }
}
