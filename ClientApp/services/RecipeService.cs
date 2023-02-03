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
    Task <IEnumerable<Recipe>> GetRecipes();

    ///Get recipe by Id
    Task<Recipe> GetRecipeById(int id);

    //Create a new recipe 
    Task<int> CreateRecipe(CreateRecipeRequest model);

    //Update a recipe
    Task UpdateRecipe(UpdateRecipeRequest model);

    //Delete a recipe
    Task DeleteRecipe(int id);
  }

  public class RecipeService: IRecipeService
  {
    private BrewingContext _dbContext;
    private readonly IMapper _mapper;

    public RecipeService(BrewingContext dbContext, IMapper mapper)
    {
      
    }
  }
}

