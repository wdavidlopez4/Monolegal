using Monolegal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monolegal.Application.Core.ViewModels
{
    public class RegistroVM
    {
        public IEnumerable<Factura> Facturas { get; set; }

        public Factura factura { get; set; }
    }
}
