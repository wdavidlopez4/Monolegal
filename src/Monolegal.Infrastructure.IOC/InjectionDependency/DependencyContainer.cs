using Microsoft.Extensions.DependencyInjection;
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

        public static void InyectarAjustes(IServiceCollection services)
        {
            
        }

    }
}
