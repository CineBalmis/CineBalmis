using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.views.logeado
{
    internal class LogeadoVM: ObservableObject
    {
        private string empleado;
        public string Empleado { get => empleado; set => SetProperty(ref empleado, value); }

        public LogeadoVM()
        {
            WeakReferenceMessenger.Default.Register<LogeadoTipoMessage>(this, (r, m) => Empleado = m.Value);
        }
    }
}
