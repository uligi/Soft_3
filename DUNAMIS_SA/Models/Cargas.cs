using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Cargas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCargas { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; }

        [Required]
        [StringLength(255)]
        public string Destino { get; set; } = string.Empty;

        [Required]
        public int TipoDeCargaID { get; set; }

        [ForeignKey("TipoDeCargaID")]
        public TipoDeCarga TipoDeCarga { get; set; } 

        [Required]
        public int ClienteID { get; set; }

        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }
    }
}
