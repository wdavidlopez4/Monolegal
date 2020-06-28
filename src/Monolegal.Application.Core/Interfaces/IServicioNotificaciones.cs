using Monolegal.Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Application.Core.Interfaces
{
    public interface IServicioNotificaciones
    {
        public Task<RegistroVM> GetRegistros();

        public void EnviarCorreoDesactivacion();

        public void EnviarNotificaciones();

    }
}
