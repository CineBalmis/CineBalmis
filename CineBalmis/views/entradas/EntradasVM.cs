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

namespace CineBalmis.views.Entradas
{
    internal class EntradasVM : ObservableObject
    {
        // Servicios
        private DAOVentas dao;

        // Comandos - Click
        public RelayCommand AddEntradasButtonClick { get; }

        private ObservableCollection<Ventas> ventas;

        public ObservableCollection<Ventas> Ventas { get => ventas; set => SetProperty(ref ventas, value); }

        public EntradasVM() {
            dao = new();

            AddEntradasButtonClick = new RelayCommand(AddEntradasButtonClicked);

            Ventas = dao.obtenerVentas();
        }
        private void AddEntradasButtonClicked()
        {

        }

    }
}
