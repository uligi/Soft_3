using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public int DistritoID { get; set; }

        [Required]
        public int CantonID { get; set; }

        [Required]
        public int ProvinciaID { get; set; }

        [ForeignKey("DistritoID")]
        public Distrito Distrito { get; set; }

        [ForeignKey("CantonID")]
        public Canton Canton { get; set; }

        [ForeignKey("ProvinciaID")]
        public Provincia Provincia { get; set; }

        public ICollection<Persona> Personas { get; set; }

        public Direccion()
        {
            Descripcion = string.Empty;
            Distrito = new Distrito();
            Canton = new Canton();
            Provincia = new Provincia();
            Personas = new HashSet<Persona>();
        }
    }
}
