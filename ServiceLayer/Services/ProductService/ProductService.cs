using Microsoft.AspNetCore.Http;
using ServiceLayer.Services.ProductService.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ServiceLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;
        private static SqlConnection _sqlConnection { get; set; }

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }
        public List<ImageModels> CoffeImg()
        {
            List<ImageModels> getImg = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetCoffeImg", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    getImg = new List<ImageModels>();
                    while (myReader.Read())
                    {
                        getImg.Add(new ImageModels
                        {
                            ProductID = myReader.GetInt32(0),
                            ProductNames = myReader.GetString(1),
                            ProductDescription = myReader.GetString(2),
                            ProductPrice = myReader.GetInt32(3),
                            ProductImages = myReader.GetString(5)
                        });
                    }
                }
            }
            finally
            {
                myReader.Close();
                _sqlConnection.Close();
            }
            return getImg;
        }
        public List<ImageModels> CakeImg()
        {
            List<ImageModels> getImg = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("spGetCakeImg", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;            
            try
            {
                _sqlConnection.Open();
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    getImg = new List<ImageModels>();
                    while (myReader.Read())
                    {
                        getImg.Add(new ImageModels
                        {
                            ProductID = myReader.GetInt32(0),
                            ProductNames = myReader.GetString(1),
                            ProductDescription = myReader.GetString(2),
                            ProductPrice = myReader.GetInt32(3),
                            ProductImages = myReader.GetString(5)
                        });
                    }
                }
            }
            finally
            {
                myReader.Close();
                _sqlConnection.Close();
            }
            return getImg;
            
        }

        public void NewProduct(string Name, string Description, int Price, int Quantity, IFormFile UploadFile, string Type) 
        {
            SqlCommand myCommand = new SqlCommand("spInsertNewProduct", _sqlConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ProductName", Name);
            myCommand.Parameters.AddWithValue("@ProductDescription", Description);
            myCommand.Parameters.AddWithValue("@ProductPrice", Price);
            myCommand.Parameters.AddWithValue("@ProductQuantity", Quantity);
            myCommand.Parameters.AddWithValue("@PathToImg", @$"/Photos/UploadImg/{ UploadFile.FileName}");
            myCommand.Parameters.AddWithValue("@Type", Type);
            try
            {
                _sqlConnection.Open();
                if (UploadFile != null)
                {
                    //Take the input image and throw it at /UploadImg folder on the Solution.
                    string path = $@"C:\Users\bria7621\Source\Repos\coffeehouse\WebUI\wwwroot\Photos\UploadImg\{UploadFile.FileName}";
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        UploadFile.CopyTo(fileStream);
                    }
                    myCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                _sqlConnection.Close();
            }

        }
    }
}
