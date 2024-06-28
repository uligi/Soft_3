using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoDeCarga
    {
        [Key]
        public int TipoDeCargaID { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        [Required]
        public decimal TarifaPorKilo { get; set; }
        public ICollection<Carga> Cargas { get; set; }
    }
}
