using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly string connectionString = 
            "Data Source=10.135.71.145;Initial Catalog=CoffeShop;Integrated Security=True";
        
        public bool Contact(string Email, string Text)
        {
            string queryString = $"INSERT INTO Contact (Email, Ticket) VALUES ('{Email}', '{Text}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }
    }
}
