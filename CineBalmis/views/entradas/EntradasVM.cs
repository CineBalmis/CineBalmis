using CineBalmis.data.database;
using CineBalmis.data.models;
using CineBalmis.dialogs.addVentas;
using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineBalmis.views.Entradas
{
    internal class EntradasVM : ObservableObject
    {
        // Servicios
        private NavigationService navigationService;
        private DAOVentas dao;

        // Comandos - Click
        public RelayCommand AddEntradasButtonClick { get; }

        // Variables
        private ObservableCollection<Ventas> ventas;

        public ObservableCollection<Ventas> Ventas { get => ventas; set => SetProperty(ref ventas, value); }

        public EntradasVM() {
            dao = new();
            navigationService = new();

            AddEntradasButtonClick = new RelayCommand(AddEntradasButtonClicked);

            Ventas = dao.ObtenerVentas();
        }
        private void AddEntradasButtonClicked()
        {
            bool? dialogo = navigationService.CargarAddVentasDialog().ShowDialog();
            if(dialogo != null)
            {
                if(dialogo == true)
                {
                    MessageBox.Show("Se ha añadido las nuevas ventas");
                }
            }
        }

    }
}
