using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ISIEXAM.Models
{
    public class bdISIEXAMContext : DbContext
    {
        public bdISIEXAMContext() : base("connISIEXAM") // : C'est pour implementer donc notre context implemente la base de donnée grace à son nom "connISIEXAME"
        {

        }

        // Pour transformer la table Etudiant en base de donnée
        public DbSet<Etudiant> etudiants { get; set; }

        public DbSet<Classe> classes { get; set; }

        public System.Data.Entity.DbSet<ISIEXAM.Models.CLasseViewModel> CLasseViewModels { get; set; }
     }
}