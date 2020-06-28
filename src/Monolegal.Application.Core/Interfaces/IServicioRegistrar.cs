using Monolegal.Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Application.Core.Interfaces
{
    public interface IServicioRegistrar
    {
        public Task<RegistroVM> GetRegistros();

        public Task<RegistroVM> CrearRegistro(RegistroVM registroVM);
    }
}
