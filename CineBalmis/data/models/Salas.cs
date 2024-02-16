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
        private int idSala;
        public int IdSala 
        { 
            get { return idSala; } 
            set { SetProperty(ref idSala, value);} 
        }
        private String numero;
        public String Numero 
        { 
            get { return numero; } 
            set { SetProperty(ref numero, value);} 
        }
        private int capacidad;
        public int Capacidad
        {
            get { return capacidad; }
            set { SetProperty(ref capacidad, value);}
        }
        private Boolean disponible;
        public Boolean Disponible
        {
            get { return disponible;} 
            set {  SetProperty(ref disponible, value);}
        }
        private ObservableCollection<Sesiones>? sesiones;
        public ObservableCollection<Sesiones>? Sesiones 
        { 
            get { return sesiones; } 
            set { SetProperty(ref sesiones, value); } 
        }

        public Salas() { }

        public Salas(int idSala, string numero, int capacidad, bool disponible, ObservableCollection<Sesiones>? sesiones)
        {
            IdSala = idSala;
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
            Sesiones = sesiones;
        }
    }
}
