namespace DUNAMIS_SA.Models
{
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Pago
    {
        [Key]
        public int PagoID { get; set; }

        [Required]
        [StringLength(255)]
        public string PagoDescripcion { get; set; }

        [Required]
        public int TipoPagoID { get; set; }

        [ForeignKey("TipoPagoID")]
        public TipoPago TipoPago { get; set; }
    }
}
}
