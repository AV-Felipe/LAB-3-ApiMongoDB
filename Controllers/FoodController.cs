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

        /// <summary>
        /// Buscar todos os documentos cadastrados no banco
        /// </summary>
        [HttpGet]
        public ActionResult<List<Food>> Read()
        {
            return Ok(_foodServ.Read());
        }
        

        /// <summary>
        /// Buscar um documento pelo seu guid FoodId
        /// </summary>
        /// <param name="id">FooId do documento buscado</param>
        /// <response code="200">Retorna o documento filtrado</response>
        /// <response code="204">Caso não haja qualquer documento com o id informado</response>
        [HttpGet("{id:guid}")]
        public ActionResult<Food> Find([FromRoute]Guid id)
        {
            var food = _foodServ.Find(id);
            if (food == null) return NotFound();
            return Ok(food);
        }

        
        /// <summary>
        /// Inserir um novo documento
        /// </summary>
        /// <param name="food">benefits é uma string onde cada palavra, separada por um espaço de outra, será transposta para um endereço dentro de uma array, no documento, </param>
        /// <response code="200">Caso o documento seja inserido com sucesso</response>
        [HttpPost]
        public ActionResult<Food> Create([FromBody]FoodInputDTO food)
        {
            _foodServ.Create(food);
            return Ok(food);
        }
        

        /// <summary>
        /// Atualizar um documento já cadastrado
        /// </summary>
        /// /// <param name="id">FoodId do documento a ser atualizado</param>
        /// <param name="foodIn">Novos dados para atualizar o documento indicado</param>
        /// <response code="200">Cao o documento seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um documento com este FoodId</response>
        [HttpPut("{id:guid}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody]FoodInputDTO foodIn)
        {
            var food = _foodServ.Find(id);

            if(food == null) return NotFound();

            _foodServ.Update(id, foodIn);

            return Ok();
        }

        /// <summary>
        /// Excluir um documento
        /// </summary>
        /// /// <param name="id">FoodId do documento a ser excluído</param>
        /// <response code="200">Caso o o documento tenha sido excluído</response>
        /// <response code="404">Caso não exista um documento com este FoodId</response>
        [HttpDelete("{id:guid}")]
        public ActionResult Delete([FromRoute]Guid id)
        {
            var food = _foodServ.Find(id);

            if (food == null) return NotFound();

            _foodServ.Delete(food.FoodId);

            return Ok();
        }

        /// <summary>
        /// Adicionar um novo item ao array benefits de um documento já criado
        /// </summary>
        /// /// <param name="id">FoodId do documento que receberá um novo benefício</param>
        /// <param name="benefit">Novo benefício que será adicionado à array já existente</param>
        /// <response code="200">Caso o benefício seja adicionado com sucesso</response>
        [HttpPatch("{id:guid}")]
        public ActionResult AddBenefit([FromRoute]Guid id, [FromQuery]string benefit)
        {
            var food = Find(id);
            _foodServ.AddBenefit(id, benefit);
            return Ok();
        }


        
    }
}