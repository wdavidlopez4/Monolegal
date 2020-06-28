using MongoDB.Driver;
using Monolegal.Domain.Interfaces;
using Monolegal.Infrastructure.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal.Infrastructure.DAL.Repository
{
    public class Repository<T> : IDomain<T> where T : class
    {
        private readonly IMongoCollection<T> mongoCollection;

        public Repository(IMonolegalDatabaseSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionString);
            var dadabase = cliente.GetDatabase(settings.DatabaseName);

            mongoCollection = dadabase.GetCollection<T>(settings.DatabaseName);
        }

        public async Task<T> AddObjet(T objeto)
        {
            await mongoCollection.InsertOneAsync(objeto);
            return objeto;

        }

        public async Task<IEnumerable<T>> GetAllObjet()
        {
            return await mongoCollection.Find<T>(x => true).ToListAsync();
        }

        public Task<T> GetObjet(string id)
        {
            throw new NotImplementedException();
        }

    }
}
