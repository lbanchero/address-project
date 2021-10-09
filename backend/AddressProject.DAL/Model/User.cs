using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AddressProject.DAL.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Fullname")]
        public string Fullname { get; set; }

        [BsonElement("AddressStreet")]
        public string AddressStreet { get; set; }
        
        [BsonElement("AddressLatitude")]
        public double AddressLatitude { get; set; }
        
        [BsonElement("AddressLongitude")]
        public double AddressLongitude { get; set; }
        
        [BsonElement("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}