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
    Task<int> CreateRecipe(int id);
    
  }
}

