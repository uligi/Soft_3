using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUNAMIS_SA.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        public int Cedula { get; set; }

        [Required]
        public int TipoClienteID { get; set; }

        [ForeignKey("Cedula")]
        public Persona Persona { get; set; }

        [ForeignKey("TipoClienteID")]
        public TipoCliente TipoCliente { get; set; }

        public ICollection<Carga> Cargas { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
