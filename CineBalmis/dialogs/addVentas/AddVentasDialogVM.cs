using CineBalmis.data.database;
using CineBalmis.data.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineBalmis.dialogs.addVentas
{
    internal class AddVentasDialogVM: ObservableObject
    {
        // Servicios
        private DAOVentas daoVentas;
        private DAOSesiones daoSesiones;
        private DAOSalas daoSalas;

        // Comando - Click
        public RelayCommand GuardarVentaClick {get;}

        // Variables
        private Ventas venta;
        private Sesiones? sesionSeleccionada;
        private ObservableCollection<Sesiones> sesiones;
        private int cantidad;
        private string metodo;

        public Ventas Venta { get => venta; set => SetProperty(ref venta, value); }
        public Sesiones? SesionSeleccionada { get => sesionSeleccionada; set => SetProperty(ref sesionSeleccionada, value); }
        public ObservableCollection<Sesiones> Sesiones { get => sesiones; set => SetProperty(ref sesiones, value); }
        public int Cantidad { get => cantidad; set => SetProperty(ref cantidad, value); }
        public string Metodo { get => metodo; set => SetProperty(ref metodo, value); }

        public AddVentasDialogVM()
        {
            daoVentas = new();
            daoSesiones = new();

            GuardarVentaClick = new(GuardarVentaClicked);

            Venta = new Ventas();
            Cantidad = 0;
            Sesiones = daoSesiones.obtenerSesiones();
        }
        private void GuardarVentaClicked()
        {
            if(SesionSeleccionada != null)
            {
                if (Cantidad + daoSalas.ocupacionSala(SesionSeleccionada.Sala) > daoSalas.obtenerSala(SesionSeleccionada.Sala).Capacidad)
                {
                    MessageBox.Show("No se puede superar la ocupacion de la sala", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    daoVentas.crearVenta(SesionSeleccionada.IdSesion, Cantidad, Metodo);
                    MessageBox.Show("Se ha guardado las nuevas ventas", "Registro Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Error registrar la venta, no hay sesión seleccionada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
