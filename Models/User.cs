using BakingG.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } // ruhet në DB
    public int Level { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<UserRecipe>? UserRecipes { get; set; }
}
