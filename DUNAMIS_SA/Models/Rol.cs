using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        [Required]
        public int TipoRolID { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
        [ForeignKey("TipoRolID")]
        public TipoRol TipoRol { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
