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
        private ConxBD conxBD;
        public UserModel()
        {
            conxBD = new ConxBD();
        }
        public void CreateUser(User user)
        {
            try { 
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "INSERT INTO users(user_name,user_last_name,user_email,user_password,user_gender,user_birth)VALUES(@name,@lastname,@email,@password,@gender,@birth)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@name", user.User_Name);
            comando.Parameters.AddWithValue("@lastname", user.User_last_name);
            comando.Parameters.AddWithValue("@email", user.User_Email);
            comando.Parameters.AddWithValue("@password", user.User_Password);
            comando.Parameters.AddWithValue("@gender", user.User_Gender);
            comando.Parameters.AddWithValue("@birth", user.User_Birth);
                int rowsAffected = comando.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");

                conxBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //public void CreateUser(User user)
        //{
        //    NpgsqlConnection conexion = conxBD.EstablecerConexion();
        //    NpgsqlCommand comando = new NpgsqlCommand("CALL procedures.create_user(@name,@lastname,@email,@password,@gender,@birth,@image)", conexion);
        //    comando.Parameters.AddWithValue("@name",user.User_Name);
        //    comando.Parameters.AddWithValue("@lastname", user.User_last_name);
        //    comando.Parameters.AddWithValue("@email", user.User_Email);
        //    comando.Parameters.AddWithValue("@password", user.User_Password);
        //    comando.Parameters.AddWithValue("@gender", user.User_Gender);
        //    comando.Parameters.AddWithValue("@birth", user.User_Birth);
        //    comando.Parameters.AddWithValue("@image", user.User_Profile_Image);
        //    NpgsqlDataReader lector = comando.ExecuteReader();
        //    while (lector.Read())
        //    {
        //        _ = new User()
        //        {
        //            User_Name = lector.GetString(0),
        //            User_last_name = lector.GetString(1),
        //            User_Email = lector.GetString(2),
        //            User_Password = lector.GetString(3),
        //            User_Gender = lector.GetChar(4),
        //            User_Birth = lector.GetDateTime(5),
        //        };
        //    }
        //    conxBD.CerrarConexion();
        //}


    }
}
