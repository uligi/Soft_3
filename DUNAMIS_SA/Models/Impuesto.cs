using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Impuesto
    {
        [Key]
        public int ImpuestoID { get; set; }

        [Required]
        public decimal Impuestos { get; set; }

        [Required]
        public int TipoImpuestoID { get; set; }

        [ForeignKey("TipoImpuestoID")]
        public TipoImpuesto TipoImpuesto { get; set; }

        public ICollection<DetalleDeFactura> DetallesDeFactura { get; set; }
    }
}
