using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.API.Data
{
    public class CookbookRepository : ICookbookRepository
    {
        private readonly DataContext _context;
        public CookbookRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(u => u.Id == id);

            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsForRecipe(int recipeId)
        {
            var ingredients = await _context.Ingredients.Where(i => i.RecipeId == recipeId).ToListAsync();

            return ingredients;
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();

            return recipes;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RecipeExists(string recipeName)
        {
            if (await _context.Recipes.AnyAsync(x => x.Name == recipeName))
                return true;

            return false;
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            var recipeToSave = new Recipe {
                Name = recipe.Name,
                Ingredients = new List<Ingredient>(),
                UserId = recipe.UserId
            };

            await _context.Recipes.AddAsync(recipeToSave);
            await _context.SaveChangesAsync();

            return recipe;
        }
    }
}