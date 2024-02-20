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
        static SqliteConnection connection = Conexion.crearConexion();
        public ObservableCollection<Sesiones> obtenerSesiones()
        {
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

        public bool editarSesion(Sesiones sesion)
        {
            bool hecho = false;
            DAOSalas daoSalas = new DAOSalas();
            if (!daoSalas.salaDisponible(sesion.Sala) && existeSesion(sesion.IdSesion) && !salaTiene3Sesiones(sesion.Sala))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE sesiones SET pelicula = @pelicula, sala = @sala, hora = @hora WHERE idSesion = @idSesion";
                comando.Parameters.Add("@pelicula", SqliteType.Text);
                comando.Parameters.Add("@sala", SqliteType.Integer);
                comando.Parameters.Add("@hora", SqliteType.Text);
                comando.Parameters.Add("@idSesion", SqliteType.Integer);
                comando.Parameters["@pelicula"].Value = sesion.Pelicula;
                comando.Parameters["@sala"].Value = sesion.Sala;
                comando.Parameters["@hora"].Value = sesion.Hora;
                comando.Parameters["@idSesion"].Value = sesion.IdSesion;

                hecho = comando.ExecuteNonQuery() > 0;
            }
            return hecho;
        }

        public bool crearSesion(int pelicula, int sala, string hora)
        {
            bool hecho = false;
            DAOSalas daoSalas = new DAOSalas();
            if (!daoSalas.salaDisponible(sala) && !salaTiene3Sesiones(sala))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO sesiones VALUES (null, @pelicula, @sala, @hora)";
                comando.Parameters.Add("@pelicula", SqliteType.Text);
                comando.Parameters.Add("@sala", SqliteType.Integer);
                comando.Parameters.Add("@hora", SqliteType.Text);
                comando.Parameters["@pelicula"].Value = pelicula;
                comando.Parameters["@sala"].Value = sala;
                comando.Parameters["@hora"].Value = hora;

                hecho = comando.ExecuteNonQuery() > 0;
            }
            return hecho;
        }

        public bool borrarSesion(int idSesion)
        {
            bool hecho = false;
            if (existeSesion(idSesion))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "DELETE FROM sesion WHERE idsession = @idSesion";
                comando.Parameters.Add("@idSesion", SqliteType.Text);
                comando.Parameters["@idSesion"].Value = idSesion;

                hecho = comando.ExecuteNonQuery() > 0;
            }
            return hecho;
        }

        public bool existeSesion(int idSesion)
        {
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
