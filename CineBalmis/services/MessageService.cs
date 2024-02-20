using CineBalmis.data.models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
