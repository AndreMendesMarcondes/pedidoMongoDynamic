using ADN.Domain.Domain;
using ADN.Domain.DTO.Settings;
using ADN.Domain.Interfaces.Repositorio;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ADN.Data.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly IMongoCollection<Pedido> _collection;

        public PedidoRepositorio(IOptions<MongoDBPedidoSettings> mongoEstudanteSettings)
        {
            var mongoClient = new MongoClient(mongoEstudanteSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoEstudanteSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Pedido>(mongoEstudanteSettings.Value.CollectionName);
        }

        public async Task<List<Pedido>> GetAll()
        {
            try
            {
                var result = await _collection.FindAsync(c => true);
                return result.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
