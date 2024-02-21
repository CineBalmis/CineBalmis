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

namespace CineBalmis.views.peliculas
{
    internal class PeliculasVM : ObservableObject
    {
        // Servicios
        private readonly DAOPeliculas dao;

        private ObservableCollection<data.models.Peliculas>? peliculas;
        private data.models.Peliculas? peliculaSeleccionada = null;

        public ObservableCollection<data.models.Peliculas> Peliculas{ get => peliculas ?? new(); set => SetProperty(ref peliculas, value); }
        public data.models.Peliculas? PeliculasSeleccionada { get => peliculaSeleccionada; set => SetProperty(ref peliculaSeleccionada, value); }

        public PeliculasVM() {
            dao = new();

            Peliculas = dao.ObtenerPeliculas();



        }
        
    }
}
