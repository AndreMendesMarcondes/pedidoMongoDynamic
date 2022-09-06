using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ADN.Domain.Domain
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public List<dynamic> itens { get; set; }
        public dynamic observacao { get; set; }
    }

    public class Item
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public string desc { get; set; }
    }
}
