using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbApp.Models;
public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

}
