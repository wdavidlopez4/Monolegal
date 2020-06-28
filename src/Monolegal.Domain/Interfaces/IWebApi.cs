using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Domain.Interfaces
{
    public interface IWebApi<T>
    {
        public bool EnviarSolicitud(T objeto);
    }
}
