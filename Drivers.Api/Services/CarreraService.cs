using Drivers.Api.Configurations;
using Drivers.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Drivers.Api.Services
{
    public class CarreraService
    {
        private readonly IMongoCollection<Drivers.Api.Models.Carrera> _carreraCollection;

        public CarreraService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDB =
            mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _carreraCollection =
                mongoDB.GetCollection<Drivers.Api.Models.Carrera>(databaseSettings.Value.Collections["Carreras"]);
        }
        public async Task<List<Drivers.Api.Models.Carrera>> GetAsync() =>
            await _carreraCollection.Find(_ => true).ToListAsync();

        public async Task InsertCarrera(Carrera carreraInsert)
        {
            await _carreraCollection.InsertOneAsync(carreraInsert);
        }

        public async Task DeleteCarrera(string carreraId)
        {
            var filter = Builders<Carrera>.Filter.Eq(s => s.Id, carreraId);
            await _carreraCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateCarrera(Carrera dataToUpdate)
        {
            var filter = Builders<Carrera>.Filter.Eq(s => s.Id, dataToUpdate.Id);
            await _carreraCollection.ReplaceOneAsync(filter, dataToUpdate);
        }

        public async Task<Carrera> GetCarreraById(string idToSearch)
        {
            return await _carreraCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(idToSearch) } }).Result.FirstAsync();
        }

        
    }
}
