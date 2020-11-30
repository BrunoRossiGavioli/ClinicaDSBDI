using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica_DS_BDI_MVC.Models
{
    [Table("Cidade")]
    public class CidadeModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("Estado")]
        public int CidadeId { get; set; }

        public EstadoModel Estado { get; set; }
    }
}
