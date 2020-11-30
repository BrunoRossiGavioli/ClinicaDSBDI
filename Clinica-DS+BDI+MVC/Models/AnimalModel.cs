﻿using System;
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

        [ForeignKey("Especie")]
        public int EspecieId { get; set; }
        
        [Column(TypeName = "decimal(3,2)")]
        public decimal Peso { get; set; }
        
        [Column(TypeName = "decimal(3,2)")]
        public decimal Altura { get; set; }
        
        [Column(TypeName = "decimal(3,2)")]
        public decimal Comprimento { get; set; }

        public string Pedigree { get; set; }

        [ForeignKey("Proprietario")]
        public int ProprietarioId { get; set; }

        public EspecieModel Especie { get; set; }
        public ProprietarioModel Proprietario { get; set; }

    }
}
