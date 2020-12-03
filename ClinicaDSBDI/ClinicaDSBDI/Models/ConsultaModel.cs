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

        [ForeignKey("Veterinario")]
        public int VeterinarioId { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public DateTime Data { get; set; }

        public DateTime Hora { get; set; }

        public AnimalModel Animal { get; set; }

        public VeterinarioModel Veterinario { get; set; }
        
        public HospitalModel Hospital { get; set; }
    }
}
