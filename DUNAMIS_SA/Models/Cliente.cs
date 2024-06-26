using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Cliente
    {
           
        [Key]
        public int Cedula { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; } = string.Empty;
    }
}

