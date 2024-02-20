using CineBalmis.dialogs.addSalas;
using CineBalmis.dialogs.addSesion;
using CineBalmis.dialogs.addVentas;
using CineBalmis.dialogs.editSalas;
using CineBalmis.dialogs.editSesion;
using CineBalmis.views;
using CineBalmis.views.entradas;
using CineBalmis.views.ocupacion;
using CineBalmis.views.peliculas;
using CineBalmis.views.salas;
using CineBalmis.views.sesiones;
using System.Windows.Controls;

namespace CineBalmis.services
{
    internal class NavigationService
    {
        // Vistas
        public UserControl CargarInicioView() => new InicioView();
        public UserControl CargarPeliculasView() => new PeliculasView();
        public UserControl CargarSesionesView() => new SesionesView();
        public UserControl CargarSalasView() => new SalasView();
        public UserControl CargarEntradasView() => new EntradasView();
        public UserControl CargarOcupacionView() => new OcupacionView();

        // Dialogos
        public AddSesionDialog CargarAddSesionDialog() => new AddSesionDialog();
        public EditSesionDialog CargarEditSesionDialog() => new EditSesionDialog();
        public AddSalasDialog CargarAddSalasDialog() => new AddSalasDialog();
        public EditSalasDialog CargarEditSalasDialog() => new EditSalasDialog();
        public AddVentasDialog CargarAddVentasDialog() => new AddVentasDialog();
    }
}
