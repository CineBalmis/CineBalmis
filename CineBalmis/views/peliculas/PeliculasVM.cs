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
        private DaoPeliculas dao;

        // Comandos - Click
        public RelayCommand AddPeliculaButtonClick { get; }
        public RelayCommand EditPeliculaButtonClick { get; }
        public RelayCommand DeletePeliculaButtonClick { get; }

        private ObservableCollection<Peliculas> peliculas;
        private Peliculas? peliculaSeleccionada = null;

        public ObservableCollection<Peliculas> Peliculas{ get => peliculas; set => SetProperty(ref peliculas, value); }
        public Peliculas? PeliculasSeleccionada { get => peliculaSeleccionada; set => SetProperty(ref peliculaSeleccionada, value); }

        public PeliculasVM() {
            dao = new();
        }

        
        private void AddPeliculaButtonClicked()
        {

        }
        private void EditPeliculaButtonClicked()
        {
            if(peliculaSeleccionada != null)
            {

            }
        }
        
    }
}
