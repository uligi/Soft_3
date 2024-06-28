using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Descuento
    {
        [Key]
        public int DescuentoID { get; set; }

        [Required]
        public decimal Descuentos { get; set; }

        [Required]
        public int TipoDescuentoID { get; set; }

        [ForeignKey("TipoDescuentoID")]
        public TipoDescuento TipoDescuento { get; set; }

        public ICollection<DetalleDeFactura> DetallesDeFactura { get; set; }
    }
}
