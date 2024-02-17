
using Microsoft.Data.Sqlite;
using System.IO;

namespace CineBalmis.data.database
{
    public static class Conexion
    {
        public static SqliteConnection CrearConexion()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=cinebalmis.db");

            connection.Open();
            return connection;
        }

        public static void CargarDatos(SqliteConnection connection)
        {
            string sql = File.ReadAllText("cinebalmis.db.sql");
            SqliteCommand cmd = new SqliteCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        public static void CerrarConexion(SqliteConnection connection)
        {
            connection.Close();
        }
    }
}
