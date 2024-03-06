using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Drivers.Api.Models
{
    public class Carrera
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        
    }
}
