using CineBalmis.data.database;
using CineBalmis.data.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineBalmis.services;
using System.Windows;

namespace CineBalmis.dialogs.editSalas
{
    internal class EditSalasDialogVM : ObservableObject
    {
        // Servicios
        private DaoSalas dao;

        // Comandos - Click
        public RelayCommand EditSalasButtonClick { get; }

        // Variables
        private Salas sala;

        public Salas Sala { get => sala; set => SetProperty(ref sala, value); }

        public EditSalasDialogVM()
        {
            dao = new();

            EditSalasButtonClick = new(EditSalasButtonClicked);
            WeakReferenceMessenger.Default.Register<EditSalaMessage>(this, (r,m)=> Sala = m.Value);
        }

        private void EditSalasButtonClicked()
        {
            if (sala != dao.obtenerSala(sala.IdSala))
            {
                dao.editarSalas(Sala);
                WeakReferenceMessenger.Default.Send(new EditSalaMessageSuccess(dao.editarSalas(sala)));
                MessageBox.Show("La informacion de la sala se ha actualizado", "Informacion de la sala", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
