using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cookbook.API.Data;
using Cookbook.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cookbook.API.Models;


namespace Cookbook.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
         private readonly ICookbookRepository _repo;
        private readonly IMapper _mapper;
        public RecipesController(ICookbookRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _repo.GetRecipes();

            var recipesToReturn = _mapper.Map<IEnumerable<RecipeForListDto>>(recipes);

            return Ok(recipesToReturn);
        }

        [HttpGet("{id}", Name = "GetRecipe")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe = await _repo.GetRecipe(id);

            var recipeToReturn = _mapper.Map<RecipeForDetailedDto>(recipe);

            return Ok(recipeToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, RecipeForUpdateDto recipeForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var recipeFromRepo = await _repo.GetRecipe(id);
            
            _mapper.Map(recipeForUpdateDto, recipeFromRepo);

            if (await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost("create-recipe")]
        public async Task<IActionResult> CreateRecipe(int id, RecipeForCreateDto recipeForCreateDto)
        {

            recipeForCreateDto.Name = recipeForCreateDto.Name.ToLower();

            if (await _repo.RecipeExists(recipeForCreateDto.Name))
                return BadRequest("Username already exists");


            var recipeToCreate = _mapper.Map<Recipe>(recipeForCreateDto);

            var createdRecipe = await _repo.CreateRecipe(recipeToCreate);

            var recipeToReturn = _mapper.Map<RecipeForDetailedDto>(createdRecipe);

            return CreatedAtRoute("GetRecipe", new {contoller = "Recipes", 
                id = createdRecipe.Id}, recipeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var recipeFromRepo = await _repo.GetRecipe(id);
            _repo.Delete(recipeFromRepo);

            if (await _repo.SaveAll())
                return Ok();
            
            return BadRequest("Failed to delete the photo");
        }
    }
}