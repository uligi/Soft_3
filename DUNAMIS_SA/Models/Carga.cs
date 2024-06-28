using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Carga
    {
        [Key]
        public int CargaID { get; set; }

        [Required]
        [StringLength(255)]
        public string Peso { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; }

        [Required]
        [StringLength(255)]
        public string Destino { get; set; }

        [Required]
        public int TipoDeCargaID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        public TipoDeCarga TipoDeCarga { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
