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
            string sentencia = "INSERT INTO users(user_name,user_last_name,user_email,user_password,user_gender,user_birth,user_profile_image)VALUES(@name,@lastname,@email,@password,@gender,@birth,@image)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@name", user.User_Name);
            comando.Parameters.AddWithValue("@lastname", user.User_last_name);
            comando.Parameters.AddWithValue("@email", user.User_Email);
            comando.Parameters.AddWithValue("@password", user.User_Password);
            comando.Parameters.AddWithValue("@gender", user.User_Gender);
            comando.Parameters.AddWithValue("@birth", user.User_Birth);
            comando.Parameters.AddWithValue("@image", user.User_Profile_Image);
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
       


    }
}
