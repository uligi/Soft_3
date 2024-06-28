using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoCorreo
    {
        [Key]
        public int TipoCorreoID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public ICollection<Correo> Correos { get; set; }
    }
}
