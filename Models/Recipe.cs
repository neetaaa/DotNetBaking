namespace BakingG.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredLevel { get; set; }

        public ICollection<UserRecipe> UserRecipes { get; set; }
    }

}
