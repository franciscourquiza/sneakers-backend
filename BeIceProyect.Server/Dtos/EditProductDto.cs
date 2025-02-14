using BeIceProyect.Server.Entities;

namespace BeIceProyect.Server.Dtos
{
    public class EditProductDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public List<int> Sizes { get; set; } = new();
    }
}
