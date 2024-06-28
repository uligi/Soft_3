using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class DetalleDeFactura
    {
        [Key]
        public int DetallesDeFacturaID { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int FacturaID { get; set; }
        [Required]
        public int CargasID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public int ImpuestoID { get; set; }
        [Required]
        public int DescuentoID { get; set; }
        [Required]
        public DateTime FechaEmision { get; set; }
        [ForeignKey("FacturaID")]
        public Factura Factura { get; set; }
        [ForeignKey("CargasID")]
        public Carga Carga { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuarios Usuario { get; set; }
        [ForeignKey("ImpuestoID")]
        public Impuesto Impuestos { get; set; }
        [ForeignKey("DescuentoID")]
        public Descuento Descuentos { get; set; }
    }
}
