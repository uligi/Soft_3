using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public Direccion Direccion { get; set; }
        public Telefono Telefono { get; set; }
        public Correo Correo { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }

        public Persona()
        {
            Nombre = string.Empty;
            Apellido1 = string.Empty;
            Apellido2 = string.Empty;
            Direccion = new Direccion();
            Telefono = new Telefono();
            Correo = new Correo();
            Clientes = new HashSet<Cliente>();
            Usuarios = new HashSet<Usuarios>();
        }
    }
}
