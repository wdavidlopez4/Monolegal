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
        private readonly IServicioRegistrar servicioRegistro;

        public RegistroController(IServicioRegistrar servicioRegistro)
        {
            this.servicioRegistro = servicioRegistro;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RegistroVM registro = await servicioRegistro.GetRegistros();
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
            var obj =  await servicioRegistro.CrearRegistro(registroVM);

            if(obj != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
