using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Drivers.Api.Models
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string name { get; set; } = string.Empty;
        [BsonElement("number")]
        public int number { get; set; }
        [BsonElement("team")]
        public string team { get; set; } = string.Empty;
    }
}