using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using ServiceLayer.Services.UserService.Models;
using System.Data;
using System.IO;

namespace ServiceLayer.Services.UserService
{
    public class UserService : IUserService
    {
        //private readonly string connectionString =
        //"Data Source=10.135.71.145;Initial Catalog=CoffeShop;Integrated Security=True";

        private readonly string _connectionString;
        private static SqlConnection _sqlConnection { get; set; }

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public bool AddUser(string userName, string userPassword1, string userPassword2,
            string firstName, string lastName, string email, int phoneNumber, bool createSucces)
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spSelectAllUsers", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@Firstname", firstName);
            bool UserFind = true;
            _sqlConnection.Open();
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (userName == myReader.GetString(1))
                    UserFind = false;
            }
            CloseString();
            
            if (UserFind && userPassword1 == userPassword2)
            {
                string passwordHashing = ComputeSha256Hash(userPassword1);
                SqlCommand mycommand = new SqlCommand("spAddUsers", _sqlConnection);
                mycommand.Parameters.AddWithValue("@Firstname", firstName);
                mycommand.Parameters.AddWithValue("@Lastname", lastName);
                mycommand.Parameters.AddWithValue("@Email", email);
                mycommand.Parameters.AddWithValue("@Password", userPassword1);
                mycommand.Parameters.AddWithValue("@Username", userName);
                mycommand.Parameters.AddWithValue("@Phone", phoneNumber);
                try
                {
                    _sqlConnection.Open();
                    mycommand.ExecuteNonQuery();
                    return createSucces = true;
                }
                finally
                {                    
                    CloseString();
                }
            }
            return createSucces = false;
        }
        public string LoginUser(string userName, string password)
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spLoginCheck", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@Username", userName);
            string passwordHash = ComputeSha256Hash(password);
            myCommand.Parameters.AddWithValue("@Password", passwordHash);
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader.GetString(1) == userName && passwordHash == myReader.GetString(4))
                        return "AdminSite";
                }
            }
            finally
            {
                myReader.Close();
                CloseString();
            }
            return "LoginSite";
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }
        public List<UserModels> GetUserInfo()
        {
            List<UserModels> UsersInfo = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spSelectAllUsers", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    UsersInfo = new List<UserModels>();
                    while (myReader.Read())
                    {
                        UsersInfo.Add(new UserModels
                        {
                            userName = myReader.GetString(5),
                            Email = myReader.GetString(3),
                            firstName = myReader.GetString(1),
                            lastName = myReader.GetString(2),
                            Password = myReader.GetString(4),
                            phoneNumber = myReader.GetInt32(6)
                        });
                    }
                }
            }
            finally
            {
                myReader.Close();                
                CloseString();
            }
            return UsersInfo;
            
        }
        public List<OrdersModels> GetOrders() 
        {
            List<OrdersModels> OrdersInfo = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetAllOrders", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure; 
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows) 
                {
                    OrdersInfo = new List<OrdersModels>();
                    while (myReader.Read())
                    {
                        OrdersInfo.Add(new OrdersModels
                        {
                            OrderId = myReader.GetInt32(0),
                            ProductName = myReader.GetString(2),
                            Price = myReader.GetInt32("Price"),
                            OrderDato = myReader.GetDateTime(1)
                        });
                    }
                }      
            }
            finally
            {
                myReader.Close();
                CloseString();
            }
            
            return OrdersInfo;
        }
        public List<CoffeeModels> GetCoffee() 
        {
            List<CoffeeModels> ListCoffees = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetAllCoffees", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    ListCoffees = new List<CoffeeModels>();
                    while (myReader.Read())
                    {
                        ListCoffees.Add(new CoffeeModels
                        {
                            CoffeeId = myReader.GetInt32(0),
                            CoffeeName = myReader.GetString("Name"),
                            CoffeeDescription = myReader.GetString("Description"),
                            CoffeePrice = myReader.GetInt32("Price"),
                            CoffeeQuantity = myReader.GetInt32(4),
                            PathToImg = myReader.GetString("PathToImg")
                        });
                    } 
                }
            }
            finally
            {
                myReader.Close();          
                CloseString();
            }

            return ListCoffees;
        }
        public List<CakeModels> GetCake() 
        {
            List<CakeModels> CakeInfo = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetAllCakes", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    CakeInfo = new List<CakeModels>();
                    while (myReader.Read())
                    {
                        CakeInfo.Add(new CakeModels
                        {
                            CakeId = myReader.GetInt32(0),
                            CakeName = myReader.GetString(1),
                            CakeDescription = myReader.GetString(2),
                            CakePrice = myReader.GetInt32(3),
                            CakeQuantity = myReader.GetInt32(4),
                            PathToImg = myReader.GetString(5),
                            Type = myReader.GetString(6)
                        });
                    }
                }
                
            }
            finally
            {
                myReader.Close();           
                CloseString();
            }
            return CakeInfo;
            
        }
        public void BuyProduct(DateTime dato, int ProductID, int Amount, string ProductName, int Price, string OrderNote)
        {
            SqlCommand myCommand = new SqlCommand("spInsertOrders", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@BuyDato", dato);
            myCommand.Parameters.AddWithValue("@Product_ID", ProductID);
            myCommand.Parameters.AddWithValue("@Amount", Amount);
            myCommand.Parameters.AddWithValue("@ProductName", ProductName);
            myCommand.Parameters.AddWithValue("@Price", Price);
            try
            {
                _sqlConnection.Open();
                if (OrderNote == null)
                {
                    OrderNote = "EMPTY";
                    myCommand.Parameters.AddWithValue("@OrderNote", OrderNote);
                }
                myCommand.ExecuteNonQuery();
            }
            finally
            {                
                CloseString();
            }
           
        }
        public ProductModels GetProductById(int Id)
        {
            ProductModels ProductInfo = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetProductById", _sqlConnection);
            myCommand.Parameters.AddWithValue("ProductID", Id);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    //ProductInfo = new List<ProductModels>();
                    while (myReader.Read())
                    {
                        ProductInfo = new ProductModels
                        {
                            ProductId = myReader.GetInt32(0),
                            ProductName = myReader.GetString(1),
                            ProductPrice = myReader.GetInt32(3),
                            ProductDescription = myReader.GetString(2)
                        };
                    }
                }
            }
            finally
            {
                myReader.Close();               
                CloseString();
            }
            return ProductInfo;
        }
        public OrdersModels GetLastOrder() 
        {
            OrdersModels OrderInfo = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetLastOrder", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    OrderInfo = new OrdersModels();
                    while (myReader.Read())
                    {
                        OrderInfo = new OrdersModels
                        {
                            OrderId = myReader.GetInt32(0),
                            OrderDato = myReader.GetDateTime(1),
                            ProductName = myReader.GetString(2),
                            Quantity = myReader.GetInt32(4),
                            Price = myReader.GetInt32(5),
                            OrderNote = myReader.GetString(6)
                            
                        };
                    }
                    OrderInfo.TotalOrder = OrderInfo.Quantity * OrderInfo.Price;
                }
            }
            finally
            {
                myReader.Close();                
                CloseString();
            }
            return OrderInfo;
        }
        public string CoffeUpdate(int productID, string productName, string productDescription, int productPrice)
        {
            SqlCommand myCommand = new SqlCommand("spUpdateCoffe", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductID", productID);
            myCommand.Parameters.AddWithValue("@ProductName", productName);
            myCommand.Parameters.AddWithValue("@ProductDescription", productDescription);
            myCommand.Parameters.AddWithValue("@ProductPrice", productPrice);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseString();
            }
            return "";
        }
        public string DeleteOrderById(int OrdersID) 
        {
            SqlCommand myCommand = new SqlCommand("spDeleteOrderById", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("OrdersID", OrdersID);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseString();
            }
            return "";
        }
        public string DeleteProductById(int ProductID) 
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand1 = new SqlCommand("spGetProductById", _sqlConnection);
            SqlCommand myCommand = new SqlCommand("spDeleteProductById", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("ProductID", ProductID);
            myCommand1.Parameters.AddWithValue("ProductID", ProductID);
            try
            {
                _sqlConnection.Open();
                myReader = myCommand1.ExecuteReader();
                while (myReader.Read())
                {

                    string reader = @$"C:\Users\bria7621\Source\Repos\coffeehouse\WebUI\wwwroot{myReader.GetString(5).Replace('/', '\\')}";
                    if (File.Exists(reader))
                    {
                        File.Delete(reader);
                    }
                }
                myReader.Close();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseString();
            }
            return "";
        }

        private void CloseString()
        {
            _sqlConnection.Close();
            //_sqlConnection.Dispose();
        }
        //"sql".Dispose() = Close all connections from SQL and throw it away.
    }
}