using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pastebin_clone_2.models;

public class Paste
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Content")]
    public string Content { get; set; } = null!;
    
}