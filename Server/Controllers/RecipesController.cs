﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Server.Models;
using Server.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IFavoriteRepository favoriteRepository;
        public static Recipe? currentRecipe;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            List<Recipe> allRecipes = await recipeRepository.GetAllAsync();

            return Ok(allRecipes);
        }
            
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetRecipeById(int Id)
        {
            Recipe? recipe = await recipeRepository.GetByIdAsync(Id);

            currentRecipe = recipe;

            if (recipe != null)
            {
                return Ok(recipe);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(RecipeCreateUpdateDTO recipeToCreateDTO)
        {

            Recipe createdRecipe = await recipeRepository.CreateAsync(recipeToCreateDTO);

            return Ok(createdRecipe);

        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateRecipe(int Id, RecipeCreateUpdateDTO updatedRecipeDTO)
        {

            Recipe? updatedRecipe = await recipeRepository.UpdateAsync(Id, updatedRecipeDTO);

            if (updatedRecipe != null) 
            {
                return Ok(updatedRecipe);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteRecipe(int Id)
        {
            Recipe? recipeToDelete = await recipeRepository.DeleteAsync(Id);

            if (recipeToDelete != null)
            {
                //Delete favorites
                List<Favorite> favorites = await favoriteRepository.GetAllFromCurrentUserAsync();
                foreach (Favorite f in favorites)
                {
                    if (f.RecipeId == Id)
                    {
                        await favoriteRepository.DeleteAsync(f.Id);
                    }
                }

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("search/{searchString}")]
        public async Task<IActionResult> SearchRecipeByName(string searchString)
        {
            List<Recipe>? foundRecipes = await recipeRepository.GetByTitleAsync(searchString);

            if (foundRecipes.Any())
            {
                return Ok(foundRecipes);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
