using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica_DS_BDI_MVC.Models
{
    [Table("Estado")]
    public class EstadoModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        
        public PaisModel Pais { get; set; }
    }
}
