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
        
        public string Nome { get; set; }

        public string Peso { get; set; }

        public string Altura { get; set; }
        
        public string Comprimento { get; set; }

        public string Pedigree { get; set; }


    }
}
