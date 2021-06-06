using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTechniqueCHEKLAT.Models
{
    public class Couleur
    {
        [Required]
        [Display(Name = "Number")]
        public int NumeroDivisible { get; set; }
        [Required]
        [Display(Name = "Libelle")]
        public string LibelleCouleur { get; set; }
        [Required]
        [Display(Name = "Color Code")]
        public string CodeCouleur { get; set; }
    }
}
