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
    public class DaoSalas
    {
        static SqliteConnection connection = null;
        public ObservableCollection<Salas> obtenerSalas()
        {
            //Abrir la conexión
            connection = Conexion.crearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Salas> salas = new ObservableCollection<Salas>();
            if (lector.HasRows)
            {
               
                while (lector.Read())
                {
                    int idSala = lector.GetInt32(0);
                    String numero = lector.GetString(1);
                    int capacidad = lector.GetInt32(2);
                    Boolean disponible = lector.GetBoolean(3);

                    Salas sala = new Salas(idSala, numero, capacidad, disponible);
                    salas.Add(sala);
                    
                }
                // Temporal
                MessageBox.Show(salas.ToString());
            }

            //Cerrar el DataReader
            lector.Close();

            //Cerrar la conexión
            Conexion.cerrarConexion(connection);

            return salas;
        }

        public void editarSalas(String numero, int capacidad, bool disponible)
        {
            if (!existeNumeroSala(numero))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE salas SET numero = @numero, capacidad = @capacidad, disponible = @disponible WHERE idSala = @idSala";
                comando.Parameters.Add("@numero", SqliteType.Text);
                comando.Parameters.Add("@capacidad", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@disponible", SqliteType.Integer);

                comando.Parameters["@numero"].Value = numero;
                comando.Parameters["@capacidad"].Value = capacidad;
                comando.Parameters["@disponible"].Value = disponible;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            // Falta añadir respuesta si ya existe la sala
        }

        public void crearSalas(String numero, int capacidad, bool disponible)
        {
            if (!existeNumeroSala(numero))
            {
                //Abrir la conexión
                connection = Conexion.crearConexion();

                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO salas VALUES (null, @numero, @capacidad, @disponible)";
                comando.Parameters.Add("@numero", SqliteType.Text);
                comando.Parameters.Add("@capacidad", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@disponible", SqliteType.Integer);

                comando.Parameters["@numero"].Value = numero;
                comando.Parameters["@capacidad"].Value = capacidad;
                comando.Parameters["@disponible"].Value = disponible;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            // Falta añadir respuesta si ya existe la sala
        }

        public bool existeNumeroSala(String numero)
        {
            //Abrir la conexión
            connection = Conexion.crearConexion();

            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas WHERE numero = @numero";
            comando.Parameters.Add("@numero", SqliteType.Text);
            comando.Parameters["@numero"].Value = numero;
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
