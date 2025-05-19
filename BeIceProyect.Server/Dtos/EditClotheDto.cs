namespace BeIceProyect.Server.Dtos
{
    public class EditClotheDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public bool IsInDiscount { get; set; }
    }
}
