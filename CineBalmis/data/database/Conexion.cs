
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Windows;

namespace CineBalmis.data.database
{
    public static class Conexion
    {
        public static SqliteConnection CrearConexion()
        {
            try{
                SqliteConnection connection = new("Data Source=../../../data/database/cinebalmis.db");
                connection.Open();
                return connection;
            }
            catch(SqliteException ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error al abrir la conexión", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
                return null;
            }
            catch(Exception ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
                return null;
            }
            
        }

        public static void CargarDatos(SqliteConnection connection)
        {
            try {
                string sql = File.ReadAllText("../../../data/database/cinebalmis.db.sql");
                SqliteCommand cmd = new SqliteCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (FileNotFoundException ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Archivo no encontrado", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
            }
            catch (IOException ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error en el proceso de entrada/salida de datos", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
            }

        }
        public static void CerrarConexion(SqliteConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqliteException ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error al cerrar la conexión", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // Muestra el problema
                MostrarDialogoExcepcion("Error", ex.Message);
                // Cierra la aplicación
                Application.Current.Shutdown();
            }
        }

        private static void MostrarDialogoExcepcion(string titulo, string mensaje)
        {
            MessageBox.Show(titulo, mensaje, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
