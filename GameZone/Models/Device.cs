namespace GameZone.Models
{
    public class Device : EntityBase
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;

        public ICollection<Game> games { get; set; } = new List<Game>();
    }
}
