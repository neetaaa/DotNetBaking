using BakingG.Data;
using BakingG.DTOs;
using BakingG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BakingG.Controllers
{
    [ApiController]
    public class SliceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SliceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ SEND SLICE
        [HttpPost("/api/slice/send")]
        public IActionResult Send([FromBody] SendSliceDto dto)
        {
            if (dto == null || dto.ToUserId == 0 || dto.FromUserId == 0)
                return BadRequest("Invalid data");

            var msg = new SliceMessage
            {
                FromUserId = dto.FromUserId,
                ToUserId = dto.ToUserId,
                Message = dto.Message,
                CreatedAt = DateTime.Now,
                IsRead = false
            };

            _context.SliceMessages.Add(msg);
            _context.SaveChanges();

            return Ok();
        }

        // ✅ INBOX
        [HttpGet("/api/slice/inbox/{userId}")]
        public IActionResult Inbox(int userId)
        {
            var messages = _context.SliceMessages
                .Where(m => m.ToUserId == userId)
                .OrderByDescending(m => m.CreatedAt)
                .Select(m => new
                {
                    m.Id,
                    m.Message,
                    m.IsRead,
                    m.CreatedAt,
                    FromUsername = _context.Users
                        .Where(u => u.Id == m.FromUserId)
                        .Select(u => u.Username)
                        .FirstOrDefault()
                })
                .ToList();

            return Ok(messages);
        }

        // ✅ MARK AS READ
        [HttpPost("/api/slice/read/{id}")]
        public IActionResult Read(int id)
        {
            var msg = _context.SliceMessages.FirstOrDefault(x => x.Id == id);
            if (msg == null) return NotFound();

            msg.IsRead = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
