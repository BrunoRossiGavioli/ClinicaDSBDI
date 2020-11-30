using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica_DS_BDI_MVC.Models
{
    [Table("Proprietario")]
    public class ProprietarioModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }
        
        public string Rua { get; set; }

        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public CidadeModel Cidade { get; set; }
    }
}
