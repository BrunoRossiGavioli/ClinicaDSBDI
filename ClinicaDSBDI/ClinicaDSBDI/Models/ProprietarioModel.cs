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

        [MaxLength(50,ErrorMessage = "O nome tem mais de {0} caracteres")]
        public string Nome { get; set; }

        [MaxLength(11, ErrorMessage = "O Cpf tem mais de {0} caracteres")]
        public string Cpf { get; set; }

        [MaxLength(9, ErrorMessage = "O Rg tem mais de {0} caracteres")]
        public string Rg { get; set; }
        
        [MaxLength(100, ErrorMessage = "O endereço tem mais de {0} caracteres")]
        public string Rua { get; set; }

        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public CidadeModel Cidade { get; set; }
    }
}
