using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoCliente
    {
        [Key]
        public int TipoClienteID { get; set; }
        [Required]
        [StringLength(45)]
        public string Descripcion { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
