using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbApp.Models;
public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

}
