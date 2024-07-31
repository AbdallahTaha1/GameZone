
namespace GameZone.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
