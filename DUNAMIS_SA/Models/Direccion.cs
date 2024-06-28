﻿using System.Collections.Generic;
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
        [ForeignKey("DistritoID")]
        public Distrito Distrito { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}
