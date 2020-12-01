using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica_DS_BDI_MVC.Models
{
    [Table("Pais")]
    public class PaisModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(60, ErrorMessage = "O Pais tem mais de {0} caracteres")]
        public string Nome { get; set; }
    }
}
