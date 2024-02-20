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

namespace CineBalmis.views.salas
{
    internal class SalasVM : ObservableObject
    {
        // Servicios
        private DAOSalas dao;
        private NavigationService navigationService;

        // Comandos - Click
        public RelayCommand EditSalasButtonClick { get; }
        public RelayCommand AddSalasButtonClick { get; }

        private ObservableCollection<Salas> salas;
        private Salas salaSeleccionada;

        public ObservableCollection<Salas> Salas { get => salas; set => SetProperty(ref salas, value); }
        public Salas SalaSeleccionada { get => salaSeleccionada; set => SetProperty(ref salaSeleccionada, value); }

        public SalasVM()
        {
            dao = new();
            navigationService = new NavigationService();

            EditSalasButtonClick = new(EditSalasButtonClicked);

            WeakReferenceMessenger.Default.Register<EditSalaMessageSuccess>(this, (r, m) => { if (m.Value) CargarSalas(); });
            CargarSalas();
        }
        private void EditSalasButtonClicked()
        {
            bool? resultado = navigationService.CargarEditSalasDialog().ShowDialog();
        }
        private void CargarSalas()
        {
            Salas = dao.obtenerSalas();
        }
    }
}
