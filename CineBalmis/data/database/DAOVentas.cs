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
                // Temporal
                MessageBox.Show(ventas.ToString());
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
                    // Temporal
                    MessageBox.Show(venta.ToString());
                }

                //Cerrar el DataReader
                lector.Close();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            }
            return venta;
        }

        public void crearVenta(int sesion, int cantidad, string pago)
        {
                //Consulta de selección
                SqliteCommand comando = connection.CreateCommand();
                comando.CommandText = "INSERT INTO sesiones VALUES (null, @sesion, @cantidad, @pago)";
                comando.Parameters.Add("@sesion", SqliteType.Integer);
                comando.Parameters.Add("@cantidad", SqliteType.Integer);
                comando.Parameters.Add("@pago", SqliteType.Text);
                comando.Parameters["@sesion"].Value = sesion;
                comando.Parameters["@cantidad"].Value = cantidad;
                comando.Parameters["@pago"].Value = pago;

                comando.ExecuteNonQuery();

                //Cerrar la conexión
                Conexion.cerrarConexion(connection);
            // Falta añadir respuesta si la sala no está disponible o tiene más de 3 sesiones asignadas.
        }

        public void borrarVentas()
        {
            //Consulta de selección
            SqliteCommand comando = connection.CreateCommand();
            comando.CommandText = "DELETE FROM ventas";

            comando.ExecuteNonQuery();

            //Cerrar la conexión
            Conexion.cerrarConexion(connection);
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
