using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FixMeApi.Models;

public class Mobile
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("DeviceName")]
    public string DeviceName { get; set; } = null!;

    public decimal AndroidVersion { get; set; }

    public string RAM { get; set; } = null!;

    public string DeviceStorage { get; set; } = null!;
    
    public DateTime DateBought { get; set; }
}