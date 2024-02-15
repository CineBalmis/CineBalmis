using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CineBalmis
{
    internal class MainWindowVM : ObservableObject
    {
        // Comandos
        public RelayCommand SalirButtonClick;
        public RelayCommand GestorButtonClick;
        public RelayCommand TrabajadorButtonClick;

        // Comandos - Navegacion
        public RelayCommand NavegarAPeliculasClick;
        public RelayCommand NavegarASesionesClick;
        public RelayCommand NavegarASalasClick;

        // Servicios


        // Referencias a variables
        private string empleado;
        private Button[] botonesNavegacion;

        public string Empleado { get => empleado; set => SetProperty(ref empleado, value); }
        public Button[] BotonesNavegacion { get => botonesNavegacion; set=>SetProperty(ref botonesNavegacion, value); } 

        public MainWindowVM()
        {
            SalirButtonClick = new(SalirSesion);
            GestorButtonClick = new(GestorBotones);
            TrabajadorButtonClick = new(TrabajadorBotones);

            // Asignar metodos a los comandos de navegacion
            NavegarAPeliculasClick = new(NavegarAPeliculas);
            NavegarASesionesClick = new(NavegarASalas);
            NavegarASalasClick = new(NavegarASesiones);

            Empleado = "Identificate";
        }

        private void SalirSesion()
        {

        }

        private void CargarBotones()
        {
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
                    Content = "Salas",
                    Command = NavegarAPeliculasClick
                };
                botones.Add(b1);
            }
            BotonesNavegacion = botones.ToArray();
        }

        private void GestorBotones()
        {
            Empleado = "Gestor";
            CargarBotones();
        }
        private void TrabajadorBotones()
        {
            Empleado = "Trabajador";
            CargarBotones();
        }

        // Implementacion metodos Comandos - Navegacion
        private void NavegarAPeliculas()
        {

        }
        private void NavegarASalas()
        {

        }
        private void NavegarASesiones() { }
    }
}
