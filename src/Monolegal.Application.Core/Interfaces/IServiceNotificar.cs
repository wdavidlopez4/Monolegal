using System;
using System.Collections.Generic;
using System.Text;
using Monolegal.Application.Core.ViewModels;

namespace Monolegal.Application.Core.Interfaces
{
    public interface IServiceNotificar
    {
        public void EnviarCorreoDesactivacion(NotificacionVM notificacionVM);

        public void EnviarNotificaciones();
    }
}
