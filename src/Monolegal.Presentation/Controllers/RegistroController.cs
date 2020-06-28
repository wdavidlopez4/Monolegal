using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monolegal.Application.Core.Interfaces;
using Monolegal.Application.Core.services;
using Monolegal.Application.Core.ViewModels;
using Monolegal.Domain.Models;

namespace Monolegal.Presentation.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IServicioNotificaciones servicioNotificaciones;

        public RegistroController(IServicioNotificaciones servicioNotificaciones)
        {
            this.servicioNotificaciones = servicioNotificaciones;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RegistroVM registro = await servicioNotificaciones.GetRegistros();
            return View(registro);
        }

        [HttpGet]
        public IActionResult CrearRegistro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRegistro([Bind("factura")] RegistroVM registroVM)
        {
            var obj =  await servicioNotificaciones.CrearRegistro(registroVM);

            if(obj != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
