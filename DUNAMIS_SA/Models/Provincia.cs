using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public ICollection<Canton> Cantones { get; set; }
    }
}
