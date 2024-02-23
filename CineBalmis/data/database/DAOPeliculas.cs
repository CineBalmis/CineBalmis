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
    public class DAOPeliculas
    {

        static SqliteConnection connection = Conexion.CrearConexion();
        public DAOPeliculas() { Conexion.CargarDatos(connection); }

        public ObservableCollection<Peliculas> ObtenerPeliculas()
        {
            //Consulta de selección
            SqliteCommand comando = connection!.CreateCommand() ?? new();
            comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Peliculas> peliculas = new();
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
                    Peliculas pelicula = new(idPelicula, titulo, cartel, anyo, genero, calificacion);
                    peliculas.Add(pelicula);
                }
            }
            //Cerrar el DataReader
            lector.Close();

            return peliculas;
        }

        public Peliculas ObtenerPelicula(int idPelicula)
        {
            Peliculas pelicula = new();
            if (ExistePelicula(idPelicula))
            {
                //Abrir la conexión
                connection = Conexion.CrearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM peliculas where idPelicula = @idPelicula";
                comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                comando.Parameters["@idPelicula"].Value = idPelicula;
                SqliteDataReader lector = comando.ExecuteReader();
                
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        idPelicula = lector.GetInt32(0);
                        String titulo = lector.GetString(1);
                        String cartel = lector.GetString(2);
                        int anyo = lector.GetInt32(3);
                        String genero = lector.GetString(4);
                        String calificacion = lector.GetString(5);
                        pelicula = new Peliculas(idPelicula, titulo, cartel, anyo, genero, calificacion);
                    }
                }

                //Cerrar el DataReader
                lector.Close();

            }
            return pelicula;
        }

        public bool ExistePelicula(int idPelicula)
        {
            //Abrir la conexión
            connection = Conexion.CrearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas WHERE idPelicula = @idPelicula";
            comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            comando.Parameters["@idPelicula"].Value = idPelicula;
            SqliteDataReader lector = comando.ExecuteReader();
            bool existe = false;
            if (lector.HasRows)
                existe = true;
            //Cerrar el DataReader
            lector.Close();
            return existe;
        }
    }
}
