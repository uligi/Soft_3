using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class DetalleDeFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDetallesDeFactura { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        [Required]
        public int FacturaID { get; set; }

        [ForeignKey("FacturaID")]
        public Factura Factura { get; set; }

        [Required]
        public int CargaID { get; set; }

        [ForeignKey("CargaID")]
        public Cargas Carga { get; set; }

        [Required]
        public int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuarios Usuario { get; set; }
    }
}
