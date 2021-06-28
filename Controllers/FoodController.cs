using System;
using System.Collections.Generic;
using CrudMongo.Models;
using CrudMongo.Models.Entities;
using CrudMongo.Services;
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

        //List all food elements
        [HttpGet]
        public ActionResult<List<Food>> Read()
        {
            return Ok(_foodServ.Read());
        }
        

        //find an especific food element by its custom foodId
        [HttpGet("{id:guid}")]
        public ActionResult<Food> Find(Guid id)
        {
            var food = _foodServ.Find(id);
            if (food == null) return NotFound();
            return Ok(food);
        }

        
        //creates a new food element
        [HttpPost]
        public ActionResult<Food> Create(FoodInputDTO food)
        {
            _foodServ.Create(food);
            return Ok(food);
        }
        

        //updates all fields of a food element
        [HttpPut("{id:guid}")]
        public ActionResult Update([FromRoute] Guid id, FoodInputDTO foodIn)
        {
            var food = _foodServ.Find(id);

            if(food == null) return NotFound();

            _foodServ.Update(id, foodIn);

            return Ok();
        }

        //deletes one food element
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var food = _foodServ.Find(id);

            if (food == null) return NotFound();

            _foodServ.Delete(food.FoodId);

            return Ok();
        }

        
    }
}