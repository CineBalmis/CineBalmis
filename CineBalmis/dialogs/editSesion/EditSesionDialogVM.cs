using CineBalmis.data.database;
using CineBalmis.data.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.dialogs.editSesion
{
    internal class EditSesionDialogVM: ObservableObject
    {
        // Servicios
        private DAOSesiones dao;

        // Comandos - Click
        public RelayCommand EditSesionButtonClick { get; }

        private Sesiones sesion;

        public Sesiones Sesion { get => sesion; set => SetProperty(ref sesion, value); }

        public EditSesionDialogVM()
        {
            dao = new DAOSesiones();

            EditSesionButtonClick = new(EditSesionButtonClicked);
        }

        private void EditSesionButtonClicked()
        {
            if(dao.obtenerSesion(sesion.IdSession) != Sesion)
            {
                dao.editarSesion(sesion.IdSession, sesion.Pelicula, sesion.Sala, sesion.Hora);
            }
        }
    }
}
