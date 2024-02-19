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

        public Sesiones obtenerSesion(int idSesion)
        {
            Sesiones sesion = new Sesiones();
            if (existeSesion(idSesion)){
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM sesiones where idSesion = @idSesion";
                comando.Parameters.Add("@idSesion", SqliteType.Integer);
                comando.Parameters["@idSesion"].Value = idSesion;
                SqliteDataReader lector = comando.ExecuteReader();
                
                if (lector.HasRows)
                {

                    while (lector.Read())
                    {
                        int pelicula = lector.GetInt32(1);
                        int sala = lector.GetInt32(2);
                        String hora = lector.GetString(3);

                        sesion = new Sesiones(idSesion, pelicula, sala, hora);

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

        public void editarSesion(int idSesion, int pelicula, int sala, string hora)
        {
            DAOSalas daoSalas = new DAOSalas();
            if (!daoSalas.salaDisponible(sala) && existeSesion(idSesion) && !salaTiene3Sesiones(sala))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE sesiones SET pelicula = @pelicula, sala = @sala, hora = @hora WHERE idSesion = @idSesion";
                comando.Parameters.Add("@pelicula", SqliteType.Text);
                comando.Parameters.Add("@sala", SqliteType.Integer);
                comando.Parameters.Add("@hora", SqliteType.Text);
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

        public void crearSesion(int pelicula, int sala, string hora)
        {
            DAOSalas daoSalas = new DAOSalas();
            if (!daoSalas.salaDisponible(sala) && !salaTiene3Sesiones(sala))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO sesiones VALUES (null, @pelicula, @sala, @hora)";
                comando.Parameters.Add("@pelicula", SqliteType.Text);
                comando.Parameters.Add("@sala", SqliteType.Integer);
                comando.Parameters.Add("@hora", SqliteType.Text);
                comando.Parameters["@pelicula"].Value = pelicula;
                comando.Parameters["@sala"].Value = sala;
                comando.Parameters["@hora"].Value = hora;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            // Falta añadir respuesta si la sala no está disponible o tiene más de 3 sesiones asignadas.
        }

        public void borrarSesion(int idSesion)
        {
            if(existeSesion(idSesion))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "DELETE FROM sesion WHERE idsession = @idSesion";
                comando.Parameters.Add("@idSesion", SqliteType.Text);
                comando.Parameters["@idSesion"].Value = idSesion;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
                // Falta añadir respuesta si la sala no está disponible o tiene más de 3 sesiones asignadas.
            }
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

        public bool salaTiene3Sesiones(int idSala)
        {
            //Abrir la conexión
            connection = Conexion.crearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT COUNT(*) FROM sesiones WHERE idSala = @idSala";
            comando.Parameters.Add("@idSala", SqliteType.Integer);
            comando.Parameters["@idSala"].Value = idSala;
            SqliteDataReader lector = comando.ExecuteReader();
            int contar = 0;
            if (lector.HasRows)
                while (lector.Read())
                {
                    contar = lector.GetInt32(0);
                }
            //Cerrar el DataReader
            lector.Close();
            return contar >= 3;
        }
    }
}
