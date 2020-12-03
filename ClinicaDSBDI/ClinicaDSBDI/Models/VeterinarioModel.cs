using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDSBDI.Models
{
    [Table("Veterinario")]
    public class VeterinarioModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }

        [MaxLength(50, ErrorMessage = "O nome tem mais de {0} caracteres")]
        public string Nome { get; set; }

        public string CRV { get; set; }

        public HospitalModel Hospital { get; set; }
    }
}
