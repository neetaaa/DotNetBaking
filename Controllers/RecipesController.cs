using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakingG.Data;
using BakingG.Models;

namespace BakingG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery] int userLevel)
        {
            var recipes = await _context.Recipes
                .Where(r => r.RequiredLevel <= userLevel)
                .ToListAsync();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }
    }
}
