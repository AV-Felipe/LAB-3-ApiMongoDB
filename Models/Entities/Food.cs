using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongo.Models.Entities
{
    public class Food
    {
        [BsonId] // indica que é a chave pimária
        [BsonRepresentation(BsonType.ObjectId)] // indica para o mongo que o que estamos passando como string deve ser entendido como um ObjectID (uma estrutura do mngo)
        public string _Id {get;set;} //o id será recebido no formato Bson (binary json) do mongoDB, as nottations acima são para lidar com esse formato, nesse campo
        public Guid FoodId {get; set;}
        public string FoodName {get; set;}
        public string FoodGroup {get; set;}
        //public BsonDocument BenefitsDoc {get; set;} //esta classe é um subdocumento (dentro de cada documento food, teremos um documento beneffits)
        public DateTime Created {get; set;}
        public DateTime LastUpdated {get; set;}
        public string[] Benefits {get; set;} //esta classe não será serializada para o banco de dados, mas será a base para entrarmos os valores do BsonDocument
    }

    
}