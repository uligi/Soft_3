using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFacturas { get; set; }

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

        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }
    }
}
