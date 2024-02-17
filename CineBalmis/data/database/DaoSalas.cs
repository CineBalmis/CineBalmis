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
        private ObservableCollection<Salas> obtenerSalas()
        {
            //Abrir la conexión
            SqliteConnection connection = Conexion.CrearConexion();

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
            Conexion.CerrarConexion(connection);

            return salas;
        }
    }
}
