using BakingG.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BakingG.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new {
                    u.Id,
                    u.Username
                })
                .ToList();

            return Ok(users);
        }
    }
}
