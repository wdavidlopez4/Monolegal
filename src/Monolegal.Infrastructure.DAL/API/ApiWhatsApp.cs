using Monolegal.Domain.Interfaces;
using Monolegal.Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Infrastructure.DAL.ApiWhatsapp
{
    public class ApiWhatsApp : IWebApi<Mensaje>
    {
        private const string KEY = "";

        public bool EnviarSolicitud(Mensaje mensaje)
        {
            var celular = mensaje.Cliente.Celular;
            var notificacion = mensaje.Notificacion;

            var client = new RestClient("https://panel.rapiwha.com/send_message.php?apikey=" + KEY + "&number=57" + celular + "&text=" + notificacion);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var seEnvio = response;
            if (seEnvio != null)
            {
                return true;
            }
            return false;
        }
    }
}
