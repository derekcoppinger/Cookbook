using System.Collections.Generic;

namespace Cookbook.API.Dtos
{
    public class RecipeForCreateDto
    {
        public string Name { get; set; }
        public List<IngredientForDetailedDto> Ingredients { get; set; }
        public int UserId { get; set; }
    }
}