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
        static SqliteConnection connection = Conexion.crearConexion();
        public ObservableCollection<Ventas> obtenerVentas()
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM ventas";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Ventas> ventas = new ObservableCollection<Ventas>();
            if (lector.HasRows)
            {

                while (lector.Read())
                {
                    int idVenta = lector.GetInt32(0);
                    int sesion = lector.GetInt32(1);
                    int cantidad = lector.GetInt32(2);
                    String pago = lector.GetString(3);

                    Ventas venta = new Ventas(idVenta, sesion, cantidad, pago);
                    ventas.Add(venta);

                }
            }

            //Cerrar el DataReader
            lector.Close();

            //Cerrar la conexión
            Conexion.cerrarConexion(connection);

            return ventas;
        }

        public Ventas obtenerVenta(int idVenta)
        {
            Ventas venta = new Ventas();
            if (existeVenta(idVenta))
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
                Conexion.cerrarConexion(connection);
            }
            return venta;
        }

        public bool crearVenta(int? sesion, int cantidad, string pago)
        {
            bool hecho = false;
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "INSERT INTO sesiones VALUES (null, @sesion, @cantidad, @pago)";
            comando.Parameters.Add("@sesion", SqliteType.Integer);
            comando.Parameters.Add("@cantidad", SqliteType.Integer);
            comando.Parameters.Add("@pago", SqliteType.Text);
            comando.Parameters["@sesion"].Value = sesion;
            comando.Parameters["@cantidad"].Value = cantidad;
            comando.Parameters["@pago"].Value = pago;

            hecho = comando.ExecuteNonQuery() > 0;

            return hecho;
        }

        public bool borrarVentas()
        {
            bool hecho = false;
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "DELETE FROM ventas";

            hecho = comando.ExecuteNonQuery() > 0;

            return hecho;
        }



        public bool existeVenta(int idVenta)
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
