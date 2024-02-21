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
        private readonly DAOSesiones dao;
        private readonly NavigationService navigationService;

        // Comandos - Click
        public RelayCommand AddSesionButtonClick { get; }
        public RelayCommand EditSesionButtonClick { get; }
        public RelayCommand DeleteSesionButtonClick { get; }

        private ObservableCollection<data.models.Sesiones>? sesiones;
        private data.models.Sesiones? sesionSeleccionada;

        public ObservableCollection<data.models.Sesiones> Sesiones { get => sesiones ?? new(); set => SetProperty(ref sesiones, value); }
        private data.models.Sesiones? SesionSeleccionada { get => sesionSeleccionada; set => SetProperty(ref sesionSeleccionada, value); }

        public SesionesVM()
        {
            dao = new DAOSesiones();
            navigationService = new NavigationService();

            AddSesionButtonClick = new RelayCommand(AddSesionButtonClicked);
            EditSesionButtonClick = new RelayCommand(EditSessionButtonClicked);
            DeleteSesionButtonClick = new RelayCommand(DeleteSessionButtonClicked);

            WeakReferenceMessenger.Default.Register<SeleccionadaSesionMessage>(this, (r, m) => { SesionSeleccionada = m.Value; });

            Sesiones = dao.obtenerSesiones();
        }

        private void AddSesionButtonClicked()
        {
           bool? dialogo =  navigationService.CargarAddSesionDialog().ShowDialog();
            if (dialogo == true && SesionSeleccionada != null)
            {
                dao.crearSesion(SesionSeleccionada.Pelicula, SesionSeleccionada.Sala, SesionSeleccionada.Hora);
            }
        }
        private void EditSessionButtonClicked() { }
        private void DeleteSessionButtonClicked() { }
    }
}
