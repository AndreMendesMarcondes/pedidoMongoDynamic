using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization.Formatters.Binary;

namespace ADN.Domain.Domain
{
    [BsonIgnoreExtraElements]
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Valor { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class PedidoInsertDTO
    {
        public object Valor { get; set; }
    }

    public class PedidoGetDTO
    {
        public string? Id { get; set; }
        public object Valor { get; set; }
    }
}
