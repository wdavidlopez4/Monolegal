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
    public class ServicioNotificaciones : IServiceNotificar
    {
        public readonly IDomain<Cliente> domain;

        public readonly IWebApi<Mensaje> webApi;
        
        public ServicioNotificaciones(IDomain<Cliente> domain, IWebApi<Mensaje> webApi)
        {
            this.domain = domain;
            this.webApi = webApi;
        }


        public async void EnviarCorreoDesactivacion(NotificacionVM notificacionVM)
        {
            //trae los clientes que deben 3 facturas
            var clientesQueDeben = await TraerClientesQueDebenNFacturas(3);

            //le pasamos los clientes que deben 3 factura para que nos debuelva los clientes que acumulan entre las 3 facturas 10000
            var clientesDeudaAcumulada =  VerificarClientesQueAcumolanDeuda(clientesQueDeben, 10000);

            //le enviamos los correos a los clientes morosos (3 facturas, acumulado 10000)
            Mensaje mensaje = notificacionVM.Mensaje;

            foreach (var clienteMoroso in clientesDeudaAcumulada)
            {
                //asociar el mensaje con el usuario
                clienteMoroso.mensajes.Add(mensaje);

                //falta actualizarlo en la db

                //enviarlo a la api
                webApi.EnviarSolicitud(mensaje);
            } 

        }

        //trae los clientes morosos que deben N facturas
        private async Task<IEnumerable<Cliente>> TraerClientesQueDebenNFacturas(int numeroDeFacturas)
        {
            var clientes = await domain.GetAllObjet();
            int FacturasNoPagadas;
            var clientesMorosos = new List<Cliente>();

            //recorre los clientes 
            for (int i = 0; i < clientes.Count() ; i++)
            {
                FacturasNoPagadas = 0;
                var cliente = clientes.ElementAt(i);

                //recorre las facturas de los clinetes
                for (int j = 0; j< cliente.Facturas.Count() ; j++)
                {

                    var factura = cliente.Facturas.ElementAt(j);

                    //verifico que facturas no estan pagadas
                    if (factura.Pagada == false)
                    {
                        FacturasNoPagadas++;

                        //verifico si el cliente tiene 3 facturas sin pagar 
                        if(FacturasNoPagadas >= numeroDeFacturas)
                        {
                            clientesMorosos.Append(cliente);
                        }
                    }
                }
            }

            return clientesMorosos;
        }

        //verifica que quientes deben x pesos acumulados entre las facturas
        private IEnumerable<Cliente> VerificarClientesQueAcumolanDeuda(IEnumerable<Cliente> clientes, int acumulado)
        {
            List<Cliente> clientesMorosos = new List<Cliente>();
            double totalFacturaAcumulado;

            //recorre el cliente
            for (int i = 0; i < clientes.Count(); i++)
            {
                var cliente = clientes.ElementAt(i);
                totalFacturaAcumulado = 0;

                //recorre la factura del clinete
                foreach (var factura in cliente.Facturas)
                {
                    totalFacturaAcumulado =+ factura.TotalFactura;

                    if(totalFacturaAcumulado >= acumulado)
                    {
                        clientesMorosos.Add(cliente);
                    }
                }
            }

            return clientesMorosos;
        }

        public void EnviarNotificaciones()
        {
            throw new NotImplementedException();
        }

    }
}
