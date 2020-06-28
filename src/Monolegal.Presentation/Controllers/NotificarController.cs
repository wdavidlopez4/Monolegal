using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monolegal.Application.Core.Interfaces;
using Monolegal.Application.Core.ViewModels;

namespace Monolegal.Presentation.Controllers
{
    public class NotificarController : Controller
    {
        private readonly IServiceNotificar servicioNotificacion;

        public NotificarController(IServiceNotificar servicioNotificacion)
        {
            this.servicioNotificacion = servicioNotificacion;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Mensaje")] NotificacionVM notificacionvm)
        {
            servicioNotificacion.EnviarCorreoDesactivacion(notificacionvm);
            return View();
        }
    }
}
