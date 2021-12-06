namespace Cookbook.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

        public int RecipeId { get; set; }
    }
}