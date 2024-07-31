namespace GameZone.Models
{
    public class Category : EntityBase
    {
        public ICollection<Game> games { get; set; } = new List<Game>();
    }
}
