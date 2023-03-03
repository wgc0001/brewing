using Microsoft.EntityFrameworkCore;
using AutoMapper;
using brewing.Models;
using brewing.Requests;
using BrewingData;
using brewing.Helpers;
using System;
using System.Collections.Generic;


namespace brewing.RecipeService {

  public interface IRecipeService
  {
    //Get all recipes in database
    Task <IEnumerable<Recipe>> GetAllRecipes();

    ///Get recipe by Id
    Task<Recipe> GetRecipeById(int id);

    //Create a new recipe 
    Task<int> CreateRecipe(CreateRecipeRequest model);

    //Update a recipe
    Task UpdateRecipe(int id, UpdateRecipeRequest model);

    //Delete a recipe
    Task DeleteRecipe(int id);

    // Task GetRecipeByName(string Name);

  }
  public class RecipeService: IRecipeService
  {
    private BrewingContext _dbContext;
    private readonly IMapper _mapper;

    public RecipeService(BrewingContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }
    private async Task<Recipe> _getRecipeById(int id)
    {
      Recipe? recipe = await _dbContext.Recipes
            .AsNoTracking()
            .Where(x=>x.Id ==id)
            .FirstOrDefaultAsync().ConfigureAwait(true);

      if (recipe == null)
      {
        throw new KeyNotFoundException("Book was not found in Database");
      }

      return recipe;
    }

    public async Task<int> CreateRecipe(CreateRecipeRequest model)
    {
      if (await _dbContext.Recipes.AnyAsync(x => x.Name ==model.Name))
        throw new RepositoryException($"A recipe with the name {model.Name} already exists in the database");

        Recipe recipe = _mapper.Map<Recipe>(model);

        _dbContext.Recipes.Add(recipe);
        await _dbContext.SaveChangesAsync().ConfigureAwait(true);

        return recipe.Id;
    }
    public async Task DeleteRecipe(int id)
    {
      Recipe? recipe = await _getRecipeById(id);

      _dbContext.Recipes.Remove(recipe);

    }
    public async Task<IEnumerable<Recipe>> GetAllRecipes()
    {
      return await _dbContext.Recipes
            .ToListAsync()
            .ConfigureAwait(true);
    }
    public async Task UpdateRecipe(int id, UpdateRecipeRequest model)
    {
      Recipe? recipe = await _getRecipeById(id);

      if (model.Name != recipe.Name && await _dbContext.Recipes.AnyAsync(x => x.Name == model.Name))
        throw new RepositoryException($"A recipe with the name {model.Name} already exists");

        _mapper.Map(model, recipe);
        _dbContext.Recipes.Update(recipe);
        await _dbContext.SaveChangesAsync().ConfigureAwait(true);
    }
    public async Task<Recipe> GetRecipeById(int id)
    {
      return await _getRecipeById(id);
    }

    // public async Task<Recipe> GetRecipeByName(string Name)
    // {
    //   var recipe = _dbContext.FirstOrDefault(r => r.Name ==name);

    //   return recipe;
      

    // }

  }
}

