using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.data.models
{
    public class Sesiones : ObservableObject
    {
        private int idSession;
        public int IdSession
        {
            get { return idSession; }
            set { SetProperty(ref idSession, value); }
        }
        private int pelicula;
        public int Pelicula
        {
            get { return pelicula; }
            set { SetProperty(ref pelicula, value); }
        }
        private int sala;
        public int Sala
        {
            get { return sala; }
            set { SetProperty(ref sala, value); }
        }
        private String hora;
        public String Hora
        {
            get { return hora; }
            set { SetProperty(ref hora, value); }
        }
        private ObservableCollection<Ventas>? ventas;
        public ObservableCollection<Ventas>? Ventas 
        { 
            get { return ventas; } 
            set { SetProperty(ref ventas, value); } 
        }
        public Sesiones() { }
        public Sesiones(int idSession, int pelicula, int sala, string hora, ObservableCollection<Ventas> ventas)
        {
            IdSession = idSession;
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
            Ventas = ventas;
        }
    }
}
