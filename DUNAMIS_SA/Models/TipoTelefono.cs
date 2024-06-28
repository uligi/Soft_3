using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoTelefono
    {
        [Key]
        public int TipoTelefonoID { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
    }
}
