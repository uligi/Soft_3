using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoImpuesto
    {
        [Key]
        public int TipoImpuestoID { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        public ICollection<Impuesto> Impuestos { get; set; }
    }
}
