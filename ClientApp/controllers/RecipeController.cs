using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using brewing.Models;
using BrewingData;
using brewing.RecipeService;
using brewing.Helpers;
using brewing.Requests;

namespace brewing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController:ControllerBase
    {
        private IRecipeService _RecipeService;
        private IMapper _mapper;

        public RecipeController(IRecipeService RecipeService, IMapper mapper)
        {
            _RecipeService = RecipeService;
            _mapper = mapper;
        }

        //Get api/<RecipeController>
        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            IEnumerable<Recipe> recipes = await _RecipeService.GetAllRecipes();
            return Ok(recipes);
        }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Recipe>> SearchRecipes(string name)
    {
        var recipe = _RecipeService.SearchRecipesByName(name);
        if(!recipe.Any())
        {
            return NotFound();
        }

        return Ok(recipe);
    }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(CreateRecipeRequest model)
        {
            int recipeId = await _RecipeService.CreateRecipe(model);
            
            if (recipeId !=0)
            {
                return Ok(new {message =$"Recipe was successfully created with id {recipeId}"});
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "The recipe was created in the database");
            
        }

        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, UpdateRecipeRequest model)
        {
            await _RecipeService.UpdateRecipe(id, model);
            return Ok(new {message = "The recipe was successfully updated"});

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _RecipeService.DeleteRecipe(id);
            return Ok(new {message = "Recipe was deleted"});
        }
    }
}