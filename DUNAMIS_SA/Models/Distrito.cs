using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Distrito
    {
        [Key]
        public int DistritoID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public int CantonID { get; set; }

        [ForeignKey("CantonID")]
        public Canton Canton { get; set; }

        public ICollection<Direccion> Direcciones { get; set; }
    }
}
