using System;
using System.Collections.Generic;
using System.Text;

namespace Monolegal.Domain.Models
{
    public class Factura
    {
        public Guid Id { get; set; }

        public double TotalFactura { get; set; }

        public double SubTotal { get; set; }

        public double IVA { get; set;  }

        public double Retencion { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public string Estado { get; set; }

        public bool Pagada { get; set; }

        public DateTime FechaDePago { get; set; }

        public Cliente Cliente { get; set; }
    }
}
