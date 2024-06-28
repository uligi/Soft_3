using System.ComponentModel.DataAnnotations;

namespace DUNAMIS_SA.Models
{
    public class TipoCliente
    {
        [Key]
        public int TipoClienteID { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
