using Clinica_DS_BDI_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDSBDI.Models
{
    [Table("Consulta")]
    public class ConsultaModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public DateTime DataDaConsulta { get; set; }

        public DateTime HorarioDaConsulta { get; set; }

        public AnimalModel Animal { get; set; }
    }
}
