using System.Collections.Generic;

namespace Cookbook.API.Dtos
{
    public class RecipeForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}