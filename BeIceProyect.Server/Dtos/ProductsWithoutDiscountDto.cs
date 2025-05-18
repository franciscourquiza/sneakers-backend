using BeIceProyect.Server.Entities;

namespace BeIceProyect.Server.Dtos
{
    public class ProductsWithoutDiscountDto
    {
        public List<Sneaker> Sneakers { get; set; }
        public List<Clothe> Clothes { get; set; }
        public List<Cap> Caps { get; set; }
    }
}
