using CineBalmis.data.models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineBalmis.data.database
{
    public class DAOSesiones
    {
        static SqliteConnection connection = null;
        public ObservableCollection<Sesiones> obtenerSesiones()
        {
            //Abrir la conexión
            connection = Conexion.crearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM sesiones";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Sesiones> sesiones = new ObservableCollection<Sesiones>();
            if (lector.HasRows)
            {

                while (lector.Read())
                {
                    int idSession = lector.GetInt32(0);
                    int pelicula = lector.GetInt32(1);
                    int sala = lector.GetInt32(2);
                    String hora = lector.GetString(3);

                    Sesiones sesion = new Sesiones(idSession, pelicula, sala, hora);
                    sesiones.Add(sesion);

                }
                // Temporal
                MessageBox.Show(sesiones.ToString());
            }

            //Cerrar el DataReader
            lector.Close();

            //Cerrar la conexión
            Conexion.cerrarConexion(connection);

            return sesiones;
        }

        public Sesiones obtenerSesion(int idSesiones)
        {
            Sesiones sesion = new Sesiones();
            if (existeSesion(idSesiones)){
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM sesiones where idSesiones = @idSesiones";
                comando.Parameters.Add("@idSesiones", SqliteType.Integer);
                comando.Parameters["@idSesiones"].Value = idSesiones;
                SqliteDataReader lector = comando.ExecuteReader();
                
                if (lector.HasRows)
                {

                    while (lector.Read())
                    {
                        int idSession = lector.GetInt32(0);
                        int pelicula = lector.GetInt32(1);
                        int sala = lector.GetInt32(2);
                        String hora = lector.GetString(3);

                        sesion = new Sesiones(idSession, pelicula, sala, hora);

                    }
                    // Temporal
                    MessageBox.Show(sesion.ToString());
                }

                //Cerrar el DataReader
                lector.Close();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            

            return sesion;
        }

        public void editarSesiones(int idSesion, int pelicula, int sala, string hora)
        {
            DAOSalas daoSalas = new DAOSalas();
            if (!daoSalas.salaDisponible(sala) && existeSesion(idSesion))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE sesiones SET pelicula = @pelicula, sala = @sala, hora = @hora WHERE idSesion = @idSesion";
                comando.Parameters.Add("@pelicula", SqliteType.Text);
                comando.Parameters.Add("@sala", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@hora", SqliteType.Integer);
                comando.Parameters.Add("@idSesion", SqliteType.Integer);
                comando.Parameters["@pelicula"].Value = pelicula;
                comando.Parameters["@sala"].Value = sala;
                comando.Parameters["@hora"].Value = hora;
                comando.Parameters["@idSesion"].Value = idSesion;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            // Falta añadir respuesta si la sala no está disponible o tiene más de 3 sesiones asignadas.
        }

        public bool existeSesion(int idSesion)
        {
            //Abrir la conexión
            connection = Conexion.crearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas WHERE idSesion = @idSesion";
            comando.Parameters.Add("@idSesion", SqliteType.Integer);
            comando.Parameters["@idSesion"].Value = idSesion;
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
