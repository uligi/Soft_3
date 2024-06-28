using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoPago
    {
        [Key]
        public int TipoPagoID { get; set; }
        [Required]
        [StringLength(255)]
        public string Tipo { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
