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
    public class DAOVentas
    {
        private  readonly SqliteConnection connection = Conexion.crearConexion();
        public DAOVentas() { Conexion.CargarDatos(connection); }
        public ObservableCollection<Ventas> ObtenerVentas()
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM ventas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Ventas> ventas = new();
            if (lector.HasRows)
            {

                while (lector.Read())
                {
                    int idVenta = lector.GetInt32(0);
                    int sesion = lector.GetInt32(1);
                    int cantidad = lector.GetInt32(2);
                    String pago = lector.GetString(3);

                    Ventas venta = new(idVenta, sesion, cantidad, pago);
                    ventas.Add(venta);

                }
            }

            //Cerrar el DataReader
            lector.Close();

            //Cerrar la conexión
            Conexion.CerrarConexion(connection);

            return ventas;
        }

        public Ventas ObtenerVenta(int idVenta)
        {
            Ventas venta = new();
            if (ExisteVenta(idVenta))
            {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM ventas where idVenta = @idVenta";
                comando.Parameters.Add("@idVenta", SqliteType.Integer);
                comando.Parameters["@idVenta"].Value = idVenta;
                SqliteDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {

                    while (lector.Read())
                    {
                        int sesion = lector.GetInt32(1);
                        int cantidad = lector.GetInt32(2);
                        String pago = lector.GetString(3);

                        venta = new Ventas(idVenta, sesion, cantidad, pago);
                    }
                }

                //Cerrar el DataReader
                lector.Close();

                //Cerrar la conexión
                Conexion.CerrarConexion(connection);
            }
            return venta;
        }

        public bool CrearVenta(int? sesion, int cantidad, string pago)
        {
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "INSERT INTO sesiones VALUES (null, @sesion, @cantidad, @pago)";
            comando.Parameters.Add("@sesion", SqliteType.Integer);
            comando.Parameters.Add("@cantidad", SqliteType.Integer);
            comando.Parameters.Add("@pago", SqliteType.Text);
            comando.Parameters["@sesion"].Value = sesion;
            comando.Parameters["@cantidad"].Value = cantidad;
            comando.Parameters["@pago"].Value = pago;

            bool hecho = comando.ExecuteNonQuery() > 0;

            return hecho;
        }

        public bool BorrarVentas()
        {
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "DELETE FROM ventas";

            bool hecho = comando.ExecuteNonQuery() > 0;

            return hecho;
        }



        public bool ExisteVenta(int idVenta)
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM ventas WHERE idVenta = @idVenta";
            comando.Parameters.Add("@idVenta", SqliteType.Integer);
            comando.Parameters["@idVenta"].Value = idVenta;
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
