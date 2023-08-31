using Npgsql;

namespace _29_Money_Calculator.BD
{
    public class ConxBD
    {
        NpgsqlConnection conexion = new NpgsqlConnection();

        static string servidor = "otto.db.elephantsql.com";
        static string nombre_base_datos = "rdnvsuwp";
        static string usuario = "rdnvsuwp";
        static string clave = "gBu4jlEuYxYTAfPtLsJa-OgG2RWn8O1z";
        static string puerto = "5432";

        string urlConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + clave + ";" + "database=" + nombre_base_datos + ";";

        public NpgsqlConnection EstablecerConexion()
        {

            try
            {
                conexion.ConnectionString = urlConexion;
                conexion.Open();

            }

            catch (NpgsqlException e)
            {
                Console.WriteLine("No se pudo conectar a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
        public NpgsqlConnection CerrarConexion()
        {

            try
            {
                conexion.Close();

            }

            catch (NpgsqlException e)
            {
                Console.WriteLine("No se pudo cerrar la conexion a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
    }

}

