using CineBalmis.data.models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CineBalmis.services
{
    public class SeleccionadoTipoTrabajadorMessage : ValueChangedMessage<string>
    {
        public SeleccionadoTipoTrabajadorMessage(string tipoTrabajador) : base(tipoTrabajador) { }
    }
    public class SeleccionadaSesionMessage : ValueChangedMessage<Sesiones>
    {
        public SeleccionadaSesionMessage(Sesiones sesion) : base(sesion) { }
    }
    public class SeleccionadaSalaMessage: ValueChangedMessage<Salas>
    {
        public SeleccionadaSalaMessage(Salas salas) : base(salas) { }   
    }
    public class EditSalaMessageSuccess: ValueChangedMessage<bool>
    {
        public EditSalaMessageSuccess(bool edit): base(edit) { }
    }
    public class EditSalaMessage: ValueChangedMessage<Salas>
    {
        public EditSalaMessage(Salas edit) : base(edit) { }
    }
}
