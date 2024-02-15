using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis
{
    internal class MainWindowVM : ObservableObject
    {
        private string empleado;
        public string Empleado
        {
            get { return empleado; }
            set { SetProperty(ref empleado, value); }
        }

        public MainWindowVM()
        {
            Empleado = "Hola";
        }
    }
}
