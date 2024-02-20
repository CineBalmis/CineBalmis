using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.data.models
{
    public class Ventas : ObservableObject
    {
        private int idVenta;
        public int IdVenta
        {
            get { return idVenta; }
            set { SetProperty(ref idVenta, value); }
        }
        private int sesion;
        public int Sesion
        {
            get { return sesion; }
            set { SetProperty(ref sesion, value); }
        }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { SetProperty(ref cantidad, value); }
        }
        private string pago;
        public string Pago
        {
            get { return pago; }
            set { SetProperty(ref pago, value); }
        }

        public enum tipoPago
        {
            Efectivo, Tarjeta, Bizum
        }
        public Ventas(){}
        public Ventas(int idVenta, int sesion, int cantidad, string pago)
        {
            IdVenta = idVenta;
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }
    }
}
