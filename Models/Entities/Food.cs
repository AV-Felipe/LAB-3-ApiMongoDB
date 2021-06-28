using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongo.Models.Entities
{
    public class Food
    {
        [BsonId] // indica que é a chave pimária
        [BsonRepresentation(BsonType.ObjectId)] // indica para o mongo que o que estamos passando como string deve ser entendido como um ObjectID (uma estrutura do mngo)
        public string Id {get; set;} //o id será recebido no formato Bson (binary json) do mongoDB, as nottations acima são para lidar com esse formato, nesse campo
        [BsonElement("Name")] // apontamos essa propriedade como o nome da propriedade na coleção do mongoDB
        public string FoodName {get; set;}
        public string FoodGroup {get; set;}
        public DateTime Created {get; set;}
        public DateTime LastUpdated {get; set;}
    }
}