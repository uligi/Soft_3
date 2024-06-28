using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Persona
    {
        [Key]
        public int Cedula { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(255)]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(255)]
        public string Apellido2 { get; set; }
        [Required]
        public int DireccionID { get; set; }
        [Required]
        public int TelefonoID { get; set; }
        [Required]
        public int CorreoID { get; set; }
        [ForeignKey("DireccionID")]
        public Direccion Direccion { get; set; }
        [ForeignKey("TelefonoID")]
        public Telefono Telefono { get; set; }
        [ForeignKey("CorreoID")]
        public Correo Correo { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }

        public Persona()
        {
            Clientes = new HashSet<Cliente>();
            Usuarios = new HashSet<Usuarios>();
        }
    }
}
