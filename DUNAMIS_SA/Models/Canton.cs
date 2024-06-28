using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Canton
    {
        [Key]
        public int CantonID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public int ProvinciaID { get; set; }

        [ForeignKey("ProvinciaID")]
        public Provincia Provincia { get; set; }

        public ICollection<Distrito> Distritos { get; set; }
    }
}
