using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Correo
    {
        [Key]
        public int CorreoID { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        public int TipoCorreoID { get; set; }

        [ForeignKey("TipoCorreoID")]
        public TipoCorreo TipoCorreo { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
