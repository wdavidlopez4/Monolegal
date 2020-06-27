using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Domain.Interfaces
{
    public interface IDomain<T>
    {
        public Task<bool> AddObjet(T objeto);

        public Task<T> GetObjet(string id);

        public Task<IEnumerable<T>> GetAllObjet();
    }
}
