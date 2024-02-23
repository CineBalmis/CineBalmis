
using CineBalmis.data.database;
using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CineBalmis
{
    public class Model
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private object icon;
        public object Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private RelayCommand command;
        public RelayCommand Command { get => command; set => command = value; }
    }
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
        private ObservableCollection<Model>? botonesNavegacion;

        public string Empleado { get => empleado ?? "Identificate"; set => SetProperty(ref empleado, value); }
        public UserControl? ContenidoVista { get => contenidoVista; set => SetProperty(ref contenidoVista, value); }
        public ObservableCollection<Model> BotonesNavegacion { get => botonesNavegacion ?? new(); set => SetProperty(ref botonesNavegacion, value); }

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
            BotonesNavegacion = new();
            Empleado = tipoEmpleado;
            if (Empleado.Equals("Trabajador"))
            {
                BotonesNavegacion.Add(new Model() { Name = "Entradas", Icon = "/assets/ticket.ico", Command = NavegarAEntradasClick });
                BotonesNavegacion.Add(new Model() { Name = "Ocupacion", Icon = "/assets/ocupacion.ico", Command = NavegarAOcupacionClick });
                
                NavegarALogeado();
                WeakReferenceMessenger.Default.Send(new LogeadoTipoMessage(Empleado));
            }
            else if (Empleado.Equals("Gestor"))
            {
                BotonesNavegacion.Add(new Model() { Name = "Peliculas", Icon = "/assets/movies.ico", Command = NavegarAPeliculasClick });
                BotonesNavegacion.Add(new Model() { Name = "Salas", Icon = "/assets/sala.ico", Command = NavegarASalasClick });
                BotonesNavegacion.Add(new Model() { Name = "Sesiones", Icon = "/assets/sesiones.ico", Command = NavegarASesionesClick });
                
                NavegarALogeado();
                WeakReferenceMessenger.Default.Send(new LogeadoTipoMessage(Empleado));
            }
            else
            {
                NavegarAInicio();
            }
        }

        // Implementacion metodos Navegacion
        private void NavegarAInicio() { ContenidoVista = navegacionService.CargarInicioView(); }
        private void NavegarALogeado() { ContenidoVista = navegacionService.CargarLogeadoView(); }

        // Implementacion metodos Comandos - Navegacion
        private void NavegarAPeliculas()
        {
            if (Empleado.Equals("Gestor"))
            {
                ContenidoVista = navegacionService.CargarPeliculasView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NavegarAInicio();
            }
        }
        private void NavegarASalas()
        {

            if (Empleado.Equals("Gestor"))
            {
                ContenidoVista = navegacionService.CargarSalasView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NavegarAInicio();
            }
        }
        private void NavegarASesiones()
        {
            if (Empleado!.Equals("Gestor"))
            {
                ContenidoVista = navegacionService.CargarSesionesView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NavegarAInicio();
            }
        }
        private void NavegarAEntradas()
        {
            ContenidoVista = navegacionService.CargarEntradasView();
            if (Empleado!.Equals("Trabajador"))
            {
                ContenidoVista = navegacionService.CargarEntradasView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NavegarAInicio();
            }
        }
        private void NavegarAOcupacion()
        {
            if (Empleado!.Equals("Trabajador"))
            {
                ContenidoVista = navegacionService.CargarOcupacionView();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NavegarAInicio();
            }
        }
    }
}
