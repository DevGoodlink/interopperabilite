using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace interroperabilite.Model
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        public  string Nom { get; set; }
        public string Prenom { get; set; }
    }
}