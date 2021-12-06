using System.Collections.Generic;

namespace Cookbook.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}