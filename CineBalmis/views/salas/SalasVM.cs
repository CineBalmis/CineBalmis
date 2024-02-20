using CineBalmis.data.database;
using CineBalmis.data.models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.views.salas
{
    internal class SalasVM : ObservableObject
    {
        // Servicios
        private DAOSalas dao;

        private ObservableCollection<Salas> salas;
        private Salas salaSeleccionada;

        public ObservableCollection<Salas> Salas { get => salas; set => SetProperty(ref salas, value); }
        public Salas SalaSeleccionada { get => salaSeleccionada; set => SetProperty(ref salaSeleccionada, value); }

        public SalasVM() {
            dao = new();

            Salas = dao.obtenerSalas();
        }
    }
}
