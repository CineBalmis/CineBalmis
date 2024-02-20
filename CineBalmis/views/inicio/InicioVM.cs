using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineBalmis.services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using static CineBalmis.services.MessageService;

namespace CineBalmis.views.inicio
{
    internal class InicioVM : ObservableObject
    {
        public RelayCommand TrabajadorButtonClickedCommand { get; private set; }
        public RelayCommand GestorButtonClickedCommand { get; private set; }

        public InicioVM()
        {
            GestorButtonClickedCommand = new(GestorButtonClicked);
            TrabajadorButtonClickedCommand = new(TrabajadorButtonClicked);
        }

        private void GestorButtonClicked() { EnviarMensaje("Gestor"); }
        private void TrabajadorButtonClicked() { EnviarMensaje("Trabajador"); }
        private void EnviarMensaje(string tipoEmpleado) { WeakReferenceMessenger.Default.Send(new SeleccionadoTipoTrabajadorMessage(tipoEmpleado)); }
    }
}
