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

namespace CineBalmis.dialogs.addSesion
{
    internal class AddSesionDialogVM : ObservableObject
    {
        // Servicios
        private DAOSesiones dao;

        // Comandos - Click
        public RelayCommand AddSesionButtonClick { get; }

        private Sesiones sesion;

        public Sesiones Sesion { get => sesion; set => SetProperty(ref sesion, value); }

        public AddSesionDialogVM()
        {
            messageService = new();
            WeakReferenceMessenger.Default.Register<MessageService.SeleccionadaSesionMessage>(this, (r, m) => Sesion = m.Value); ;
        }

        private void AddSesionButtonClicked()
        {
            WeakReferenceMessenger.Default.Send(messageService.);
        }



    }
}
