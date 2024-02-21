using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.data.models
{
    public class Salas : ObservableObject
    {
        private int? idSala;
        public int? IdSala 
        { 
            get { return idSala; } 
            set { SetProperty(ref idSala, value);} 
        }
        private string? numero;
        public string? Numero 
        { 
            get { return numero; } 
            set { SetProperty(ref numero, value);} 
        }
        private int? capacidad;
        public int? Capacidad
        {
            get { return capacidad; }
            set { SetProperty(ref capacidad, value);}
        }
        private bool? disponible;
        public bool? Disponible
        {
            get { return disponible;} 
            set {  SetProperty(ref disponible, value);}
        }

       

        public Salas() { }

        public Salas(int? idSala, string numero, int capacidad, bool disponible)
        {
            IdSala = idSala;
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
        }
    }
}
