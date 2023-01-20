using Microsoft.EntityFrameworkCore;
using AutoMapper;
using brewing.Models;
using brewing.Requests;
using BrewingContext;

namespace brewing.RecipeService {
    public interface IRecipeService {
      // Get all recipes in the database
      Task<IEnumerable<Recipe>> GetAllRecipes();

      //Get a recipe by Name
      Task<Recipe> GetRecipeByName(string Name);

      //Get recipe by ingredient
      Task<Recipe> GetRecipeByMalt(string Malts);

      //Create new recipe
      Task<int> CreateRecipe(CreateRecipeRequest model);

      //Update recipe if it already exists
      Task UpdateRecipe(int id, UpdateRecipeRequest model);

      //Delete recipe
      Task DeleteRecipe(int id);

    }

    public class RecipeService: IRecipeService {
        private ProjectContext _dbcontext;
        private readonly IMapper _mapper;

        public RecipeService(ProjectContext dbcontext, IMapper imapper){

          _dbcontext =_dbcontext;
          _mapper = _mapper;

        }

        public async Task<int> CreateRecipe(CreateRecipeRequest model) {
            // Validate new recipe
            if (await _dbcontext.Recipes.AnyAsync(x => x.Name == model.Name))
                throw new Exception($"An author with the name {model.Name} already exists.");

            Recipe recipe = _mapper.Map<Recipe>(model);

            _dbcontext.Recipes.Add(recipe);
            await _dbcontext.SaveChangesAsync().ConfigureAwait(true);

            if (recipe != null)
            {
                return recipe.Id;
            }

            return 0;
        }

        public async Task DeleteRecipe(int id){
          Recipe? recipe = await _getRecipeById(id);
          
          _dbcontext.Recipes.Remove(recipe);
          await _dbcontext.SaveChangesAsync().ConfigureAwait(true);

        }

        private async Task<Recipe> _getRecipeById(int id)
        {
            Recipe? recipe = await  _dbcontext.Recipes
                  .AsNoTracking()
                  .Where(x=>x.Id ==id)
                  .FirstOrDefaultAsync().ConfigureAwait(true);

            if (recipe == null){
              throw new KeyNotFoundException("Recipe Not Found");
            }

        }

        public async Task<IEnumerable<Recipe>> GetRecipeByName(string Name){

          return await _getRecipeByName(Name).ConfigureAwait(true);
        }

        private Task<IEnumerable<Recipe>> _getRecipeByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipe(int id, UpdateRecipeRequest model){

          Recipe? recipe = await _getRecipeById(id).ConfigureAwait(true);

          //validate that recipe exists
          if (model.Name !=recipe.Name && await _dbcontext.Recipes.AnyAsync(x=>x.Name==model.Name))
          throw new Exception("A Recipe with this Name Does Not Exist");

          _mapper.Map(model, recipe);
          _dbcontext.Recipes.Update(recipe);
          await _dbcontext.SaveChangesAsync();



        }

        public Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        Task<Recipe> IRecipeService.GetRecipeByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetRecipeByMalt(string Malts)
        {
            throw new NotImplementedException();
        }
    }
}

