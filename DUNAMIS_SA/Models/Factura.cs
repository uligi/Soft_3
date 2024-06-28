using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal TotalSinDescuento { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        [Required]
        public decimal TotalFinal { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public int CargaID { get; set; }

        public Cliente Cliente { get; set; }
        public Carga Carga { get; set; }
        public ICollection<DetalleDeFactura> DetallesDeFactura { get; set; }
    }
}
