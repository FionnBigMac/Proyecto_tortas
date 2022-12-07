using System.ComponentModel.DataAnnotations;

namespace Proyecto_tortas.API.Models
{
    public class Alimento
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string Lugar { get; set; }
    }
}
