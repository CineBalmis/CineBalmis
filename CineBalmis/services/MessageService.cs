using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBalmis.services
{
    internal class MessageService
    {
        public class SeleccionadoTipoTrabajadorMessage : ValueChangedMessage<string>
        {
            public SeleccionadoTipoTrabajadorMessage(string tipoTrabajador) : base(tipoTrabajador) { }
        }
    }
}
