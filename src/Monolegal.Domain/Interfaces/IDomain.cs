using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Domain.Interfaces
{
    public interface IDomain<T>
    {
        public Task<T> AddObjet(T objeto);

        public Task<T> GetObjet(string id);

        public Task<IEnumerable<T>> GetAllObjet();
    }
}
