using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISIEXAM.Models
{
    public class Etudiant
    {
        [Key]
        public int IdEtudiant { get; set; }

        [Display(Name = "Nom"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string NomEtudiant { get; set; }

        [Display(Name = "Prénom"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string PrenomEtudiant { get; set; }

        [Display(Name = "Adresse"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string AdresseEtudiant { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string EmailEtudiant { get; set; }

        [RegularExpression("^(221|00221|\\+221)?(77|78|75|70|76)[0-9]{7}$", ErrorMessage = "Saisissez un numéro du Sénégal")]
        //[DataType(DataType.PhoneNumber)] A remplacer avec des expressions regulieres
        [Display(Name = "Telephone"), MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        public string TelEtudiant { get; set; }
    }
}