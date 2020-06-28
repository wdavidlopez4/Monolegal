using Microsoft.Extensions.DependencyInjection;
using Monolegal.Application.Core.Interfaces;
using Monolegal.Application.Core.services;
using Monolegal.Domain.Interfaces;
using Monolegal.Domain.Models;
using Monolegal.Infrastructure.DAL.Context;
using Monolegal.Infrastructure.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monolegal.Infrastructure.IOC.InjectionDependency
{
    public class DependencyContainer
    {

        public static void InyectarEntidadesARepositorio(IServiceCollection services)
        {
            services.AddSingleton<Repository<Factura>>();
            services.AddSingleton<Repository<Cliente>>();
        }

        public static void InyectarAApplicationCore(IServiceCollection services)
        {
            services.AddScoped<IServicioNotificaciones, ServicioNotificaciones>();
        }

        public static void InyectarADal(IServiceCollection services)
        {
            services.AddScoped<IDomain<Factura>, Repository<Factura>>();
            services.AddScoped<IDomain<Cliente>, Repository<Cliente>>();
        }

    }
}
