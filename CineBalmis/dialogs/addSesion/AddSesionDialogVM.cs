using CineBalmis.data.database;
using CineBalmis.data.models;
using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.dialogs.addSesion
{
    internal class AddSesionDialogVM : ObservableObject
    {
        // Servicios
        private DAOSesiones daoSesiones;
        private DaoSalas daoSalas;
        private DAOPeliculas daoPeliculas;

        // Comandos - Click
        public RelayCommand AddSesionButtonClick { get; }

        // Variables
        private Sesiones sesion;
        private ObservableCollection<Salas> listaSalas;
        private Salas? salaSeleccionada;
        private Peliculas? peliculaSeleccionada;
        private ObservableCollection<Peliculas> listaPeliculas;

        public Sesiones Sesion { get => sesion; set => SetProperty(ref sesion, value); }
        public ObservableCollection<Salas> ListaSalas { get => listaSalas; set=> SetProperty(ref listaSalas, value); }  
        public Salas? SalaSeleccionada { get => salaSeleccionada; set => SetProperty(ref salaSeleccionada, value); }
        public Peliculas? PeliculaSeleccionada { get => peliculaSeleccionada; set => SetProperty(ref peliculaSeleccionada, value); }
        public ObservableCollection<Peliculas> ListaPeliculas { get => listaPeliculas; set => SetProperty(ref listaPeliculas, value); }

        public AddSesionDialogVM()
        {
            daoSesiones = new();
            daoSalas = new();
            daoPeliculas = new();

            AddSesionButtonClick = new(AddSesionButtonClicked);

            ListaSalas = daoSalas.obtenerSalas();
            ListaPeliculas = daoPeliculas.obtenerPeliculas();

            WeakReferenceMessenger.Default.Register<SeleccionadaSesionMessage>(this, (r, m) => Sesion = m.Value); ;
        }

        private void AddSesionButtonClicked()
        {
            if (Sesion != daoSesiones.obtenerSesion(Sesion.IdSesion) && PeliculaSeleccionada != null && SalaSeleccionada != null)
            {
                
                daoSesiones.editarSesion(Sesion);
                WeakReferenceMessenger.Default.Send(new EditSalaMessageSuccess(true));
            }

        }



    }

}
