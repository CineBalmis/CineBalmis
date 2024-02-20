using CineBalmis.dialogs.addSesion;
using CineBalmis.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CineBalmis.services
{
    internal class NavigationService
    {
        public UserControl CargarInicioView() => new InicioView();
        public UserControl CargarPeliculasView() => new UserControl();
        public UserControl CargarSesionesView() => new UserControl();
        public UserControl CargarSalasView() => new UserControl();
        public UserControl CargarEntradasView() => new UserControl();
        public UserControl CargarOcupacionView() => new UserControl();
        public AddSesionDialog CargarAddSesionDialog() => new AddSesionDialog();
    }
}
