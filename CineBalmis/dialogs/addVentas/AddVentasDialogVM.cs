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
        private readonly DAOVentas daoVentas;
        private readonly DAOSesiones daoSesiones;
        private readonly DaoSalas daoSalas;

        // Comando - Click
        public RelayCommand GuardarVentaClick {get;}

        // Variables
        private data.models.Ventas? venta;
        private data.models.Sesiones? sesionSeleccionada;
        private ObservableCollection<data.models.Sesiones>? sesiones;
        private int? cantidad;
        private string? metodo;

        public Ventas? Venta { get => venta; set => SetProperty(ref venta, value); }
        public data.models.Sesiones? SesionSeleccionada { get => sesionSeleccionada; set => SetProperty(ref sesionSeleccionada, value); }
        public ObservableCollection<Sesiones> Sesiones { get => sesiones ?? new(); set => SetProperty(ref sesiones, value); }
        public int? Cantidad { get => cantidad; set => SetProperty(ref cantidad, value); }
        public string? Metodo { get => metodo; set => SetProperty(ref metodo, value); }

        public AddVentasDialogVM()
        {
            daoVentas = new();
            daoSesiones = new();
            daoSalas = new();

            GuardarVentaClick = new(GuardarVentaClicked);

            Venta = new Ventas();
            Cantidad = 0;
            Sesiones = daoSesiones.obtenerSesiones();
        }
        private void GuardarVentaClicked()
        {
            if(SesionSeleccionada != null)
            {
                if (Cantidad + daoSalas.OcupacionSala(SesionSeleccionada.Sala) > daoSalas.ObtenerSala(SesionSeleccionada.Sala).Capacidad)
                {
                    MessageBox.Show("No se puede superar la ocupacion de la sala", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    daoVentas.CrearVenta(SesionSeleccionada.IdSesion, Cantidad ?? 0, Metodo ?? "Tarjeta");
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
