using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoDescuento
    {
        [Key]
        public int TipoDescuentoID { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        public ICollection<Descuento> Descuentos { get; set; }
    }
}
