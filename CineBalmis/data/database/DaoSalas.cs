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
    public class DAOSalas
    {
        static SqliteConnection connection = Conexion.crearConexion();
        public ObservableCollection<Salas> obtenerSalas()
        {
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
            }

            //Cerrar el DataReader
            lector.Close();

            return salas;
        }

        public Salas obtenerSala(int idSala)
        {
            Salas sala = new Salas();
            if (existeSala(idSala))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM salas where idSala = @idSala";
                comando.Parameters.Add("@idSala", SqliteType.Integer);
                comando.Parameters["@idSala"].Value = idSala;
                SqliteDataReader lector = comando.ExecuteReader();
                
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        idSala = lector.GetInt32(0);
                        String numero = lector.GetString(1);
                        int capacidad = lector.GetInt32(2);
                        Boolean disponible = lector.GetBoolean(3);

                        sala = new Salas(idSala, numero, capacidad, disponible);
                    }
                    // Temporal
                    MessageBox.Show(sala.ToString());
                }
                //Cerrar el DataReader
                lector.Close();
                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            return sala;
        }

        public static int GetOcupacionSala(int? idSala)
        {
            int ocupacion = 0;

            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText =
                "SELECT SUM(ventas.cantidad) AS 'ocupacion'" +
                "FROM salas JOIN sesiones JOIN ventas " +
                "ON salas.idSala = sesiones.sala AND sesiones.idSesion = ventas.sesion " +
                "WHERE salas.idSala = " + idSala + " " +
                "GROUP BY sesiones.idSesion";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    ocupacion = (int)(long)lector["ocupacion"];
                }
            }
            return ocupacion;
        }

        public bool editarSalas(Salas sala)
        {
            bool hecho = false;
            if (!existeNumeroSala(sala.Numero) && existeSala(sala.IdSala))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE salas SET numero = @numero, capacidad = @capacidad, disponible = @disponible WHERE idSala = @idSala";
                comando.Parameters.Add("@numero", SqliteType.Text);
                comando.Parameters.Add("@capacidad", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@disponible", SqliteType.Integer);
                comando.Parameters.Add("@idSala", SqliteType.Integer);
                comando.Parameters["@numero"].Value = sala.Numero;
                comando.Parameters["@capacidad"].Value = sala.Capacidad;
                comando.Parameters["@disponible"].Value = sala.Disponible;
                comando.Parameters["@idSala"].Value = sala.IdSala;

                hecho = comando.ExecuteNonQuery() > 0;
            }
            return hecho;
        }

        public void crearSala(Salas sala)
        {
            if (!existeNumeroSala(sala.Numero))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO salas VALUES (null, @numero, @capacidad, @disponible)";
                comando.Parameters.Add("@numero", SqliteType.Text);
                comando.Parameters.Add("@capacidad", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@disponible", SqliteType.Integer);

                comando.Parameters["@numero"].Value = sala.Numero;
                comando.Parameters["@capacidad"].Value = sala.Capacidad;
                comando.Parameters["@disponible"].Value = sala.Disponible;

                comando.ExecuteNonQuery();
            }
            // Falta añadir respuesta si ya existe la sala
        }

        public bool existeSala(int idSala)
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas WHERE idSala = @idSala";
            comando.Parameters.Add("@idSala", SqliteType.Integer);
            comando.Parameters["@idSala"].Value = idSala;
            SqliteDataReader lector = comando.ExecuteReader();
            bool existe = false;
            if (lector.HasRows)
                existe = true;
            //Cerrar el DataReader
            lector.Close();
            return existe;
        }

        public bool existeNumeroSala(String numero)
        {
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

        public bool salaDisponible(int idSala)
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas WHERE idSala = @idSala AND disponible = 1";
            // 1 significando true.
            comando.Parameters.Add("@numero", SqliteType.Text);
            comando.Parameters["@numero"].Value = idSala;
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
