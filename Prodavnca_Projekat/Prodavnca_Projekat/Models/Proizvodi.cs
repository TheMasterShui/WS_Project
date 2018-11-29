using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prodavnca_Projekat.Models
{
    [Table(name: "Proizvodi")]
    public class Proizvodi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProizvodID { get; set; }

        [Required(ErrorMessage = "Polje 'Naziv' je obavezno!")]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje 'Opis' je obavezno!")]
        [StringLength(400)]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Polje 'Kategorija' je obavezno!")]
        [StringLength(50)]
        public string Kategorija { get; set; }

        [Required(ErrorMessage = "Polje 'Proizvodjac' je obavezno!")]
        [StringLength(50)]
        public string Proizvodjac { get; set; }

        [Required(ErrorMessage = "Polje 'Dobavljac' je obavezno!")]
        [StringLength(50)]
        public string Dobavljac { get; set; }
        
        public decimal Cena { get; set; }


    }
}