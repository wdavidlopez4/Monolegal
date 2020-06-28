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
        private readonly IDomain<Factura> domain;

        public ServicioNotificaciones(IDomain<Factura> domain)
        {
            this.domain = domain;
        }


        public async Task<RegistroVM> CrearRegistro(RegistroVM registroVM)
        {
            Factura f = registroVM.factura;

            return new RegistroVM()
            {
               factura  = await domain.AddObjet(f)
            };
        }


        public async Task<RegistroVM> GetRegistros()
        {
            IEnumerable<Factura> facturas = await domain.GetAllObjet();

            return new RegistroVM()
            {
                Facturas = facturas
            };
        }

        public void EnviarCorreoDesactivacion()
        {
            throw new NotImplementedException();
        }

        public void EnviarNotificaciones()
        {
            throw new NotImplementedException();
        }
    }
}
