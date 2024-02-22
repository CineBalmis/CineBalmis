using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CineBalmis.data.models.Peliculas;

namespace CineBalmis.data.models
{
    public class Ventas : ObservableObject
    {
        private int? idVenta;
        public int? IdVenta
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
        private TipoPago pago;
        public TipoPago Pago
        {
            get { return pago; }
            set { SetProperty(ref pago, value); }
        }

        public enum TipoPago
        {
            Efectivo, Tarjeta, Bizum, Indefinido
        }
        public Ventas(){}
        public Ventas(int? idVenta, int sesion, int cantidad, string pago)
        {
            IdVenta = idVenta;
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = ParseTipoPago(pago);
        }
        private static TipoPago ParseTipoPago(string pago)
        {

            if (!Enum.TryParse(pago, true, out TipoPago tipoPagoParseado))
            {
                tipoPagoParseado = TipoPago.Indefinido;
            }
            return tipoPagoParseado;
        }
    }
}
