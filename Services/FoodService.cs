using System;
using System.Collections.Generic;
using CrudMongo.Models;
using CrudMongo.Models.Entities;
using MongoDB.Driver;


namespace CrudMongo.Services
{
    public class FoodService
    {
        private readonly IMongoCollection<Food> _food;

        public FoodService (IDatabaseSettings settings) //o IdatabaseSettings é injetado com o DatabaseSetings do appsetings.json
        {
            var client = new MongoClient(settings.ConnectionString); //mongoclient lê a instância do servidor para realizar as operações de BD
            var database = client.GetDatabase(settings.DatabaseName);
            _food = database.GetCollection<Food>("Foods"); // busca a colection Foods no banco e injeta no objeto Food
        }

        public Food Create(FoodInputDTO food)
        {
            var foodInsert = new Food
            {
                FoodId = Guid.NewGuid(),
                FoodName = food.FoodName,
                FoodGroup = food.FoodGroup,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now

            };
            _food.InsertOne(foodInsert);
            return foodInsert;
        }

        //lista todas as entradas
        //public IList<Food> Read() =>
        //    _food.Find(sub => true).ToList();
        public List<Food> Read() => _food.Find(sub => true).ToList();

        //busca um id (single) ou null se não achar nenhum (default)
        public Food Find(Guid id) =>
            _food.Find(sub => sub.FoodId == id).SingleOrDefault();

        //esse é o put, atualiza todos os campos do item
        public void Update(Guid id, Food food) =>
            _food.ReplaceOne(sub => sub.FoodId == food.FoodId, food );
        
        public void Delete(Guid id) =>
            _food.DeleteOne(sub => sub.FoodId == id);

    }
}