using CineBalmis.data.database;
using CineBalmis.data.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.views.ocupacion
{
    internal class OcupacionVM : ObservableObject
    {
        // Servicios
        private DaoSalas dao;

        // Comandos - Click
        public RelayCommand ActualizarButtonClick { get; }

        // Variables
        private ObservableCollection<(Salas, int)> ocupaciones;
        
        public ObservableCollection<(Salas, int)> Ocupaciones { get => ocupaciones; set => SetProperty(ref ocupaciones, value); }

        public OcupacionVM() {
            dao = new();
            ActualizarButtonClick = new(ObtenerOcupacion);

            ObtenerOcupacion();           
        }
        private void ObtenerOcupacion()
        {
            ObservableCollection<Salas> salas = dao.obtenerSalas();

            foreach (Salas s in salas)
            {
                Ocupaciones.Add((s, dao.ocupacionSala(s.IdSala)));
            }
        }
    }
}
