using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeIceProyect.Server.Entities
{
    public class Sneaker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public List<SneakersSize> Sizes { get; set; } = new();
        public bool IsInDiscount { get; set; } = false;
    }
}
