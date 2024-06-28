using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Factura
    {
        [Key]
        public int FacturasID { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal TotalSinDescuento { get; set; }
        [Required]
        public decimal TotalFinal { get; set; }
        [Required]
        public int ClienteID { get; set; }
        [Required]
        public int CargasID { get; set; }
        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }
        [ForeignKey("CargasID")]
        public Carga Carga { get; set; }
        public ICollection<DetalleDeFactura> DetallesDeFactura { get; set; }
    }
}
