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
        static readonly SqliteConnection connection = Conexion.crearConexion();
        public DaoSalas() { Conexion.cargarDatos(connection); }
        public ObservableCollection<Salas> ObtenerSalas()
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Salas> salas = new();
            if (lector.HasRows)
            {
               
                while (lector.Read())
                {
                    int idSala = lector.GetInt32(0);
                    String numero = lector.GetString(1);
                    int capacidad = lector.GetInt32(2);
                    Boolean disponible = lector.GetBoolean(3);

                    Salas sala = new(idSala, numero, capacidad, disponible);
                    salas.Add(sala);
                }
            }

            //Cerrar el DataReader
            lector.Close();

            return salas;
        }

        public Salas ObtenerSala(int? idSala)
        {
            Salas sala = new();
            if (ExisteSala(idSala))
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
                }
                //Cerrar el DataReader
                lector.Close();
                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            return sala;
        }

        public int OcupacionSala(int? idSala)
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
                    ocupacion = lector.GetInt32(0);
                }
            }
            return ocupacion;
        }

        public bool EditarSalas(Salas sala)
        {
            bool hecho = false;
            if (!ExisteNumeroSala(sala.Numero) && ExisteSala(sala.IdSala))
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

        public bool CrearSala(string? numero, int? capacidad, int? disponible)
        {
            bool hecho = false;
            if (!ExisteNumeroSala(numero))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO salas VALUES (null, @numero, @capacidad, @disponible)";
                comando.Parameters.Add("@numero", SqliteType.Text);
                comando.Parameters.Add("@capacidad", SqliteType.Integer);
                // Es Boolean, pero no hay SqliteType.Boolean, falta probarlo.
                comando.Parameters.Add("@disponible", SqliteType.Integer);

                comando.Parameters["@numero"].Value = numero;
                comando.Parameters["@capacidad"].Value =capacidad;
                comando.Parameters["@disponible"].Value = disponible;

                hecho = comando.ExecuteNonQuery() > 0;
            }
            return hecho;
        }

        public bool ExisteSala(int? idSala)
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

        public bool ExisteNumeroSala(string? numero)
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

        public bool SalaDisponible(int? idSala)
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
