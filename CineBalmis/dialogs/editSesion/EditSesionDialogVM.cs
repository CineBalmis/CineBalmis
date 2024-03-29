﻿using CineBalmis.data.database;
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
    internal class EditSesionDialogVM : ObservableObject
    {
        // Servicios
        private readonly DAOSesiones dao;

        // Comandos - Click
        public RelayCommand? EditSesionButtonClick { get; }

        private data.models.Sesiones? sesion;

        public data.models.Sesiones? Sesion { get => sesion ?? new(); set => SetProperty(ref sesion, value); }

        public EditSesionDialogVM()
        {
            dao = new DAOSesiones();

            EditSesionButtonClick = new(EditSesionButtonClicked);
        }

        private void EditSesionButtonClicked()
        {
            if (Sesion != null  && dao.obtenerSesion(Sesion!.IdSesion) != Sesion)
            {
                dao.editarSesion(Sesion);
            }
        }
    }
}
