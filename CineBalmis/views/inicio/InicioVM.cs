using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineBalmis.services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CineBalmis.views.inicio
{
    internal class InicioVM : ObservableObject
    {
        public RelayCommand TrabajadorButtonClick { get; private set; }
        public RelayCommand GestorButtonClick { get; private set; }

        public InicioVM()
        {
            GestorButtonClick = new(GestorButtonClicked);
            TrabajadorButtonClick = new(TrabajadorButtonClicked);
        }

        private void GestorButtonClicked() { EnviarMensaje("Gestor"); }
        private void TrabajadorButtonClicked() { EnviarMensaje("Trabajador"); }
        private void EnviarMensaje(string tipoEmpleado) { WeakReferenceMessenger.Default.Send(new SeleccionadoTipoTrabajadorMessage(tipoEmpleado)); }
    }
}
