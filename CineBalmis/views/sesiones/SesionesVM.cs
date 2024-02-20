using CineBalmis.data.database;
using CineBalmis.data.models;
using CineBalmis.dialogs.addSesion;
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

namespace CineBalmis.views.sesiones
{
    internal class SesionesVM : ObservableObject
    {
        // Servicios
        private DAOSesiones dao;
        private NavigationService navigationService;

        // Comandos - Click
        public RelayCommand AddSesionButtonClick { get; }
        public RelayCommand EditSesionButtonClick { get; }
        public RelayCommand DeleteSesionButtonClick { get; }

        private ObservableCollection<Sesiones> sesiones;
        private Sesiones sesionSeleccionada;

        public ObservableCollection<Sesiones> Sesiones { get => sesiones; set => SetProperty(ref sesiones, value); }
        private Sesiones SesionSeleccionada { get => sesionSeleccionada; set => SetProperty(ref sesionSeleccionada, value); }

        public SesionesVM()
        {
            dao = new DAOSesiones();
            navigationService = new NavigationService();

            AddSesionButtonClick = new RelayCommand(AddSesionButtonClicked);
            EditSesionButtonClick = new RelayCommand(EditSessionButtonClicked);
            DeleteSesionButtonClick = new RelayCommand(DeleteSessionButtonClicked);

            WeakReferenceMessenger.Default.Register<MessageService.SeleccionadaSesionMessage>(this, (r, m) => { SesionSeleccionada = m.Value; });

            Sesiones = dao.obtenerSesiones();
        }

        private void AddSesionButtonClicked()
        {
           bool? dialogo =  navigationService.CargarAddSesionDialog().ShowDialog();
            if (dialogo == true)
            {
                dao.crearSesion(SesionSeleccionada.Pelicula, SesionSeleccionada.Sala, SesionSeleccionada.Hora);
            }
        }
        private void EditSessionButtonClicked() { }
        private void DeleteSessionButtonClicked() { }
    }
}
