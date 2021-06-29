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

        //creates a new Food element
        public Food Create(FoodInputDTO food)
        {
            var foodInsert = new Food
            {
                FoodId = Guid.NewGuid(),
                FoodName = food.FoodName,
                FoodGroup = food.FoodGroup,
                Benefits = food.Benefits.Split(" "),
                Created = DateTime.Now,
                LastUpdated = DateTime.Now

            };
            _food.InsertOne(foodInsert);
            return foodInsert;
        }

        //List all food elements
        public List<Food> Read() => _food.Find(sub => true).ToList();

        //busca um id (single) ou null se não achar nenhum (default)
        public Food Find(Guid id) => _food.Find(sub => sub.FoodId == id).SingleOrDefault();

        //esse é o put, atualiza todos os campos do item
        public void Update(Guid id, FoodInputDTO foodReplacement) 
        {
            var food = Find(id);

            if(food != null)
            {
                food.FoodName = foodReplacement.FoodName;
                food.FoodGroup = foodReplacement.FoodGroup;
                food.Benefits = foodReplacement.Benefits.Split(" ");
                food.Created = food.Created;
                food.LastUpdated = DateTime.Now;
            }
                        
            _food.ReplaceOne(foodOnDb => foodOnDb.FoodId == food.FoodId, food );
        }
        
        
        public void Delete(Guid id) => _food.DeleteOne(foodOnDb => foodOnDb.FoodId == id);

        public void AddBenefit (Guid id, string benefit)
        {
            var food = Find(id);
            string foodString = benefit;
                        
            if(food != null)
            {
                foreach(string x in food.Benefits)
                {
                    foodString = x + " " + foodString;
                    
                }
                FoodInputDTO foodReplace = new FoodInputDTO{FoodName=food.FoodName, FoodGroup=food.FoodGroup, Benefits=foodString};
                Update(id, foodReplace);
            }
            
        }

    }
}