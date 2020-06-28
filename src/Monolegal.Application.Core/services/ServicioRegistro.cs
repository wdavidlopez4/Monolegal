using Monolegal.Application.Core.Interfaces;
using Monolegal.Application.Core.ViewModels;
using Monolegal.Domain.Interfaces;
using Monolegal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Application.Core.services
{
    public class ServicioRegistro : IServicioRegistrar
    {
        private readonly IDomain<Factura> domain;

        public ServicioRegistro(IDomain<Factura> domain)
        {
            this.domain = domain;
        }

        //crea el regstro
        public async Task<RegistroVM> CrearRegistro(RegistroVM registroVM)
        {
            Factura f = registroVM.factura;

            return new RegistroVM()
            {
               factura  = await domain.AddObjet(f)
            };
        }

        //deviuelve el registro
        public async Task<RegistroVM> GetRegistros()
        {
            IEnumerable<Factura> facturas = await domain.GetAllObjet();

            return new RegistroVM()
            {
                Facturas = facturas
            };
        }

    }
}
