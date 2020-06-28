using Monolegal.Application.Core.Interfaces;
using Monolegal.Application.Core.ViewModels;
using Monolegal.Domain.Interfaces;
using Monolegal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Application.Core.services
{
    public class ServicioNotificaciones : IServicioNotificaciones
    {
        private readonly IDomain<Cliente> domain;

        public ServicioNotificaciones(IDomain<Cliente> domain)
        {
            this.domain = domain;
        }


        public void EnviarCorreoDesactivacion()
        {
            throw new NotImplementedException();
        }

        public void EnviarNotificaciones()
        {
            throw new NotImplementedException();
        }

        public async Task<RegistroVM> GetRegistros()
        {
            IEnumerable<Cliente> clientes = await domain.GetAllObjet();

            return new RegistroVM()
            {
                Clientes = clientes
            };
        }
    }
}
