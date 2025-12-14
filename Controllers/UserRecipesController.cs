using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakingG.Data;
using BakingG.Models;

namespace BakingG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CompleteRecipe([FromBody] UserRecipe userRecipe)
        {
            var recipe = await _context.Recipes.FindAsync(userRecipe.RecipeId);
            if (recipe == null) return NotFound("Recipe not found");

            var exists = await _context.UserRecipes
                .AnyAsync(ur => ur.UserId == userRecipe.UserId && ur.RecipeId == userRecipe.RecipeId);
            if (exists) return BadRequest("Recipe already completed");

            _context.UserRecipes.Add(userRecipe);

            var user = await _context.Users.FindAsync(userRecipe.UserId);
            if (user.Level < recipe.RequiredLevel)
            {
                user.Level = recipe.RequiredLevel;
            }

            await _context.SaveChangesAsync();
            return Ok("Recipe completed");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserRecipes(int userId)
        {
            var completed = await _context.UserRecipes
                .Include(ur => ur.Recipe)
                .Where(ur => ur.UserId == userId)
                .ToListAsync();

            return Ok(completed);
        }
    }
}
