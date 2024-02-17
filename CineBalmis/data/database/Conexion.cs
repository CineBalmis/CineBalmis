
using Microsoft.Data.Sqlite;
using System.IO;

namespace CineBalmis.data.database
{
    public class Conexion
    {
        public SqliteConnection CrearConexion()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=cinebalmis.db");

            connection.Open();
            return connection;
        }

        public void CargarDatos(SqliteConnection connection)
        {
            string sql = File.ReadAllText("cinebalmis.db.sql");
            SqliteCommand cmd = new SqliteCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
        public void CerrarConexion(SqliteConnection connection)
        {
            connection.Close();
        }
    }
}
