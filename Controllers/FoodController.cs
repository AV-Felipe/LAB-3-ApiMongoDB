using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using CrudMongo.Models.Entities;
using CrudMongo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace CrudMongo.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly FoodService _foodServ;

        public FoodController(FoodService foodService)
        {
            _foodServ = foodService;
        }

        [HttpGet]
        public ActionResult<List<Food>> Read() => _foodServ.Read();

        [HttpGet("{id:length(24)}", Name = "ReadFood")]
        public ActionResult<Food> Find(string id)
        {
            var food = _foodServ.Find(id);
            if (food == null) return NotFound();
            return food;
        }

        

        [HttpPost]
        public ActionResult<Food> Create(Food food)
        {
            _foodServ.Create(food);
            return CreatedAtRoute("ReadFood", new {id = food.Id.ToString()}, food);
        }
        

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Food foodIn)
        {
            var food = _foodServ.Find(id);

            if(food == null) return NotFound();

            _foodServ.Update(id, foodIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var food = _foodServ.Find(id);

            if (food == null) return NotFound();

            _foodServ.Delete(food.Id);

            return NoContent();
        }

        
    }
}