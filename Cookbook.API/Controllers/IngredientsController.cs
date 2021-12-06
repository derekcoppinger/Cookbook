using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cookbook.API.Data;
using Cookbook.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cookbook.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
         private readonly ICookbookRepository _repo;
        private readonly IMapper _mapper;
        public IngredientsController(ICookbookRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("{recipeId}", Name = "GetIngredient")]
        public async Task<IActionResult> GetIngredientsForRecipe(int recipeId)
        {
            var ingredients = await _repo.GetIngredientsForRecipe(recipeId);

            var ingredientsToReturn = _mapper.Map<IEnumerable<IngredientForListDto>>(ingredients);

            return Ok(ingredientsToReturn);
        }

    }
}