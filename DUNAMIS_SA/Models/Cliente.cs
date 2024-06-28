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
        [Required]
        public int PagoID { get; set; }
        [ForeignKey("Cedula")]
        public Persona Persona { get; set; }
        [ForeignKey("TipoClienteID")]
        public TipoCliente TipoCliente { get; set; }
        [ForeignKey("PagoID")]
        public Pago Pago { get; set; }
        public ICollection<Carga> Cargas { get; set; }
        public ICollection<Factura> Facturas { get; set; }

        public Cliente()
        {
            Cargas = new HashSet<Carga>();
            Facturas = new HashSet<Factura>();
        }
    }
}
