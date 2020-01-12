using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace interroperabilite.Model
{
    public class Matiere
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Coef { get; set; }
    }
}