using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoRol
    
    {
        [Key]
        public int TipoRolID { get; set; }
        [Required]
        [StringLength(45)]
        public string Descripcion { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
