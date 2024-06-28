using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(255)]
        public string Correo { get; set; }
        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }
        [Required]
        public int RolID { get; set; }
        [Required]
        public int Cedula { get; set; }
        [ForeignKey("RolID")]
        public Rol Rol { get; set; }
        [ForeignKey("Cedula")]
        public Persona Persona { get; set; }
    }
}
