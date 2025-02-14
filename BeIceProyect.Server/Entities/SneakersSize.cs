using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeIceProyect.Server.Entities
{
    public class SneakersSize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Clave primaria
        public int Size { get; set; } // Número de talle
        public int SneakerId { get; set; } // Clave foránea
        [JsonIgnore]
        public Sneaker Sneaker { get; set; } // Relación inversa
    }
}
