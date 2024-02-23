using CineBalmis.data.database;
using CineBalmis.data.models;
using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.dialogs.addSalas
{
    internal class AddSalasDialogVM: ObservableObject
    {
        // Servicios
        private DAOSalas dao;

        // Comandos - Click
        public RelayCommand AddSalasButtonClick { get; }

        private Salas salas;

        public Salas Salas { get => salas; set => SetProperty(ref salas, value); }

        public AddSalasDialogVM()
        {
            dao = new DAOSalas();

            Salas = new Salas();

            AddSalasButtonClick = new(AddSalasButtonClicked);
        }
        private void AddSalasButtonClicked()
        {
            dao.CrearSala(Salas.Numero, Salas.Capacidad, 0);
        }

        
    }
}
