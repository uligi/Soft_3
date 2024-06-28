using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class DetalleDeFactura
    {
        [Key]
        public int DetalleDeFacturaID { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        [Required]
        public int FacturaID { get; set; }

        [Required]
        public int CargaID { get; set; }

        [Required]
        public int UsuarioID { get; set; }

        [Required]
        public int ImpuestoID { get; set; }

        [Required]
        public int DescuentoID { get; set; }

        [Required]
        public DateTime FechaDeEmision { get; set; }

        public Factura Factura { get; set; }
        public Carga Carga { get; set; }
        public Usuarios Usuario { get; set; }
        public Impuesto Impuestos { get; set; }
        public Descuento Descuentos { get; set; }
    }
}
