using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica_DS_BDI_MVC.Models
{
    [Table("Animal")]
    public class AnimalModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O nome tem mais de {0} caracteres")]
        public string Nome { get; set; }

        [ForeignKey("Proprietario")]
        public int ProprietarioId { get; set; }

        [ForeignKey("Especie")]
        public int EspecieId { get; set; }
        
        public decimal Peso { get; set; }
        
        public decimal Altura { get; set; }
        
        public decimal Comprimento { get; set; }
        
        [MaxLength(22, ErrorMessage = "O pedigree tem mais de {0} caracteres")]
        public string Pedigree { get; set; }

        public EspecieModel Especie { get; set; }
        public ProprietarioModel Proprietario { get; set; }

    }
}
