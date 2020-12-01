using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clinica_DS_BDI_MVC.Models;

namespace ClinicaDSBDI.Data
{
    public class ClinicaDSBDIContext : DbContext
    {
        public ClinicaDSBDIContext (DbContextOptions<ClinicaDSBDIContext> options)
            : base(options)
        {
        }

        public DbSet<Clinica_DS_BDI_MVC.Models.PaisModel> PaisModel { get; set; }

        public DbSet<Clinica_DS_BDI_MVC.Models.EstadoModel> EstadoModel { get; set; }

        public DbSet<Clinica_DS_BDI_MVC.Models.CidadeModel> CidadeModel { get; set; }

        public DbSet<Clinica_DS_BDI_MVC.Models.ProprietarioModel> ProprietarioModel { get; set; }

        public DbSet<Clinica_DS_BDI_MVC.Models.EspecieModel> EspecieModel { get; set; }

        public DbSet<Clinica_DS_BDI_MVC.Models.AnimalModel> AnimalModel { get; set; }
    }
}
