namespace BakingG.Models
{
    public class UserRecipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }
}
