using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Telefono
    {
        [Key]
        public int TelefonoID { get; set; }

        [Required]
        [StringLength(255)]
        public string Numero { get; set; }

        [Required]
        public int TipoTelefonoID { get; set; }

        [ForeignKey("TipoTelefonoID")]
        public TipoTelefono TipoTelefono { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
