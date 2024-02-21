
using CineBalmis.data.database;
using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CineBalmis
{
    internal class MainWindowVM : ObservableObject
    {
        // Comandos - Click
        public RelayCommand SalirButtonClick { get; set; }

        // Comandos - Navegacion
        public RelayCommand NavegarAPeliculasClick { get; set; }
        public RelayCommand NavegarASesionesClick { get; set; }
        public RelayCommand NavegarASalasClick { get; set; }
        public RelayCommand NavegarAEntradasClick { get; set; }
        public RelayCommand NavegarAOcupacionClick { get; set; }

        // Servicios
        private NavigationService navegacionService;
        private DAOVentas dao;

        // Referencias a variables
        private string? empleado = null;
        private UserControl? contenidoVista = null;

        public string? Empleado { get => empleado; set => SetProperty(ref empleado, value); }
        public UserControl? ContenidoVista { get => contenidoVista; set => SetProperty(ref contenidoVista, value); }

        public MainWindowVM()
        {
            // Inicializar Servicios
            navegacionService = new();
            dao = new();

            // Comandos - Click
            SalirButtonClick = new(SalirSesion);

            // Comandos - Navegacion
            NavegarAPeliculasClick = new(NavegarAPeliculas);
            NavegarASesionesClick = new(NavegarASalas);
            NavegarASalasClick = new(NavegarASesiones);
            NavegarAEntradasClick = new(NavegarAEntradas);
            NavegarAOcupacionClick = new(NavegarAOcupacion);

            WeakReferenceMessenger.Default.Register<SeleccionadoTipoTrabajadorMessage>(this, (r, m) => { CargarBotones(m.Value); });

            dao.BorrarVentas();

            // Reset del programa
            SalirSesion();
        }

        private void SalirSesion()
        {
            CargarBotones("Identificate");
            NavegarAInicio();
        }

        private void CargarBotones(string tipoEmpleado)
        {
            Empleado = tipoEmpleado;
            if (Empleado.Equals("Trabajador"))
            {
                NavegarAOcupacion();
            }
            else if(Empleado.Equals("Gestor"))
            {
                NavegarAPeliculas();
            }
            else
            {
                NavegarAInicio();
            }
        }

        // Implementacion metodos Navegacion
        private void NavegarAInicio() { ContenidoVista = navegacionService.CargarInicioView(); }

        // Implementacion metodos Comandos - Navegacion
        private void NavegarAPeliculas() { 
            if (Empleado.Equals("Gestor")){ 
                ContenidoVista = navegacionService.CargarPeliculasView(); 
            } else { 
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }
        private void NavegarASalas() { 

            if (Empleado.Equals("Gestor"))
            {
                ContenidoVista = navegacionService.CargarSalasView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NavegarASesiones() { 
            if (Empleado!.Equals("Gestor"))
            {
                ContenidoVista = navegacionService.CargarSesionesView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NavegarAEntradas() { ContenidoVista = navegacionService.CargarEntradasView();
            if (Empleado!.Equals("Trabajador"))
            {
                ContenidoVista = navegacionService.CargarEntradasView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NavegarAOcupacion() { 
            if (Empleado!.Equals("Trabajador"))
            {
                ContenidoVista = navegacionService.CargarOcupacionView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
