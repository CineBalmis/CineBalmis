using CineBalmis.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.services
{
    internal class NavigationService
    {
        public InicioView CargarInicioView() => new();
    }
}
