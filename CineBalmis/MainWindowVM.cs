
﻿using CineBalmis.services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CineBalmis
{
    internal class MainWindowVM : ObservableObject
    {
        // Comandos - Click
        public RelayCommand SalirButtonClick;
        public RelayCommand GestorButtonClick;
        public RelayCommand TrabajadorButtonClick;

        // Comandos - Navegacion
        public RelayCommand NavegarAPeliculasClick;
        public RelayCommand NavegarASesionesClick;
        public RelayCommand NavegarASalasClick;
        public RelayCommand NavegarAEntradasClick;
        public RelayCommand NavegarAOcupacionClick;

        // Servicios

        // Servicios - Navegacion
        private services.NavigationService NavigationService;


        // Referencias a variables
        private string empleado;
        private Button[] botonesNavegacion;
        private UserControl contenidoVista;

        public string Empleado { get => empleado; set => SetProperty(ref empleado, value); }
        public Button[] BotonesNavegacion { get => botonesNavegacion; set => SetProperty(ref botonesNavegacion, value); }
        public UserControl ContenidoVista { get => contenidoVista; set => SetProperty(ref contenidoVista, value); }

        public MainWindowVM()
        {
            // Inicializar Servicios
            NavigationService = new();

            // Comandos - Click
            SalirButtonClick = new(SalirSesion);
            GestorButtonClick = new(GestorBotones);
            TrabajadorButtonClick = new(TrabajadorBotones);

            // Comandos - Navegacion
            NavegarAPeliculasClick = new(NavegarAPeliculas);
            NavegarASesionesClick = new(NavegarASalas);
            NavegarASalasClick = new(NavegarASesiones);
            NavegarAEntradasClick = new(NavegarAEntradas);
            NavegarAOcupacionClick = new(NavegarAOcupacion);

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
            List<Button> botones = new();
            if (empleado.Equals("Gestor"))
            {
                Button b = new()
                {
                    Content = "Peliculas",
                    Command = NavegarAPeliculasClick
                };
                botones.Add(b);

                Button b1 = new()
                {
                    Content = "Sesiones",
                    Command = NavegarASesionesClick,
                };
                botones.Add(b1);

                Button b2 = new()
                {
                    Content = "Salas",
                    Command = NavegarASalasClick
                };
                botones.Add(b2);
            }
            else if (empleado.Equals("Trabajador"))
            {
                Button b1 = new()
                {
                    Content = "Entradas",
                    Command = NavegarAEntradasClick
                };
                botones.Add(b1);

                Button b2 = new()
                {
                    Content = "Ocupacion",
                    Command = NavegarAOcupacionClick
                };
                botones.Add(b2);
            }
            BotonesNavegacion = botones.ToArray();
        }

        private void GestorBotones() { CargarBotones("Gestor"); }
        private void TrabajadorBotones() { CargarBotones("Trabajador"); }

        // Implementacion metodos Navegacion
        private void NavegarAInicio() { ContenidoVista = NavigationService.CargarInicioView(); }

        // Implementacion metodos Comandos - Navegacion
        private void NavegarAPeliculas() { ContenidoVista = NavigationService.CargarPeliculasView(); }
        private void NavegarASalas() { ContenidoVista = NavigationService.CargarSalasView(); }
        private void NavegarASesiones() { ContenidoVista = NavigationService.CargarSesionesView(); }
        private void NavegarAEntradas() { ContenidoVista = NavigationService.CargarEntradasView(); }
        private void NavegarAOcupacion() { ContenidoVista = NavigationService.CargarOcupacionView(); }
       
    }
}
