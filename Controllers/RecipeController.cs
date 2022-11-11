using Microsoft.AspNetCore.Mvc;
using static brewing.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BrewingApp.Controllers {
    public class RecipeController: Controller {
        public IActionResult Index() {
            return View();
        }

        public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe) {
            try {
                if (recipe ==null)
                    return BadRequest()
            }
        }
    }
}