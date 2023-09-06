using _29_Money_Calculator.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using _29MoneyCalculator.Clases;
using System.Security;

namespace _29MoneyCalculator.Modelos
{
    public class UserModel
    {
        private ConxDB conxBD;
        public UserModel()
        {
            conxBD = new ConxDB();
        }
        public bool CreateUser(User user)
        {
            List<int> cantAgg = new();
            try { 
            NpgsqlConnection conexion = conxBD.Connect();
            string sentencia = "INSERT INTO users(user_name,user_last_name,user_email,user_password,user_gender,user_birth)VALUES(@name,@lastname,@email,@password,@gender,@birth)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@name", user.User_Name);
            comando.Parameters.AddWithValue("@lastname", user.User_last_name);
            comando.Parameters.AddWithValue("@email", user.User_Email);
            comando.Parameters.AddWithValue("@password", user.User_Password);
            comando.Parameters.AddWithValue("@gender", user.User_Gender);
            comando.Parameters.AddWithValue("@birth", user.User_Birth);
                int rowsAffected = comando.ExecuteNonQuery();
                cantAgg.Add(rowsAffected);
                Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");
                if (cantAgg.Count >= 1) 
                {
                    conxBD.Disconnect();
                    return true;
                }
                    conxBD.Disconnect();
                    return false;
            }

            catch (Exception ex)
            {
                conxBD.Disconnect();
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Excepción PostgreSQL: {ex.Message}");
                return false;
                
            }
        }
        public bool ValidateUser(string email,string password)
        {
            NpgsqlConnection connection = conxBD.Connect();
            string query = "SELECT user_email,user_password FROM users WHERE user_email=@email AND user_password=@password";
            NpgsqlCommand command = new (query, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                conxBD.Disconnect();
                return true;
            }
            else
            {
                conxBD.Disconnect();
                return false;
            }
        }
        public (int,string) UserInformation(string email)
        {
            NpgsqlConnection connection = conxBD.Connect();
            string query = "SELECT user_id,user_name || ' '|| user_last_name FROM users WHERE user_email=@email";
            NpgsqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@email", email);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                string user_full_name = reader.GetString(1);
                conxBD.Disconnect();
                return (id, user_full_name);
            }
            else
            {
                conxBD.Disconnect();
                return(-1,null);
            }
        }
       


    }
}
