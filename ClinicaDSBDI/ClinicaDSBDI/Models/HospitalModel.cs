using Clinica_DS_BDI_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDSBDI.Models
{
    [Table("Hospital")]
    public class HospitalModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O nome tem mais de {0} caracteres")]
        public string Nome { get; set; }

        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public CidadeModel Cidade { get; set; }

    }
}
