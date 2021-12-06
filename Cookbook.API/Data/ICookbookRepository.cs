using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.API.Models;

namespace Cookbook.API.Data
{
    public interface ICookbookRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Recipe> GetRecipe(int id);
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Ingredient> GetIngredient(int id);
        Task<IEnumerable<Ingredient>> GetIngredientsForRecipe(int recipeId);
        Task<bool> RecipeExists(string recipeName);
        Task<Recipe> CreateRecipe(Recipe recipe);
    }
}