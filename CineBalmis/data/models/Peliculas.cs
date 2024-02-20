using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.data.models
{
    public class Peliculas : ObservableObject
    {
        private int? idPelicula;
        public int? IdPelicula
        {
            get { return idPelicula; }
            set { SetProperty(ref idPelicula, value); }
        }
        private string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        private string cartel;
        public string Cartel
        {
            get { return cartel; }
            set { SetProperty (ref cartel, value); }
        }
        private int anyo;
        public int Anyo
        {
            get { return anyo; } set { SetProperty(ref anyo, value);}
        }
        private Generos genero;
        public Generos Genero
        {
            get { return genero; }
            set
            {
                SetProperty(ref genero, value);
            }
        }
        private Calificaciones calificacion;
        public Calificaciones Calificacion
        {
            get { return calificacion; }
            set { SetProperty(ref calificacion, value); }
        }
        public enum Generos
        {
            Drama, Comedia, Acción, Thriller, Terror, Animación, Indefinido
        }
        public enum Calificaciones
        {
            NRM_7, NRM_12, NRM_16,
            NRM_18 ,APTA_TP, INDEFINIDO
        }
        public Peliculas()
        {

        }

        public Peliculas(int? idPelicula, string titulo, string cartel, int anyo, string genero, string calificacion)
        {
            IdPelicula = idPelicula;
            Titulo = titulo;
            Cartel = cartel;
            Anyo = anyo;
            Genero = parseGeneros(genero);
            Calificacion = parseCalificaciones(calificacion);
        }

        private Generos parseGeneros(string genero)
        {
            Generos generoParseado;
            if (!Enum.TryParse(genero, true, out generoParseado))
            {
                generoParseado = Generos.Indefinido;
            }
            return generoParseado;
        }

        private Calificaciones parseCalificaciones(string calificacion)
        {
            Calificaciones calificacionParseada;

            if (!Enum.TryParse(calificacion, true, out calificacionParseada))
            {
                calificacionParseada = Calificaciones.INDEFINIDO;
            }
            return calificacionParseada;
        }
    }
}
