using CineBalmis.data.models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CineBalmis.data.models.Peliculas;

namespace CineBalmis.data.database
{
    public class DaoPeliculas
    {
        private ObservableCollection<Peliculas> obtenerPeliculas()
        {
            //Abrir la conexión
            SqliteConnection connection = Conexion.CrearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Peliculas> peliculas = new ObservableCollection<Peliculas>(); ;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idPelicula = lector.GetInt32(0);
                    String titulo = lector.GetString(1);
                    String cartel = lector.GetString(2);
                    int anyo = lector.GetInt32(3);
                    String genero = lector.GetString(4);
                    String calificacion = lector.GetString(5);
                    Peliculas pelicula = new Peliculas(idPelicula, titulo, cartel, anyo, genero, calificacion);
                    peliculas.Add(pelicula);
                }
                // Temporal
                MessageBox.Show(peliculas.ToString());
            }

            //Cerrar el DataReader
            lector.Close();

            //Cerrar la conexión
            Conexion.CerrarConexion(connection);

            return peliculas;
        }
    }
}
