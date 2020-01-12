using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace interroperabilite.Model
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Etudiant Etudiant { get; set; }
        [ForeignKey("Etudiant")]
        public int Idetudiant { get; set; }

        public Matiere Matiere { get; set; }
        [ForeignKey("Matiere")]
        public int Idmatiere { get; set; }

        public float NoteObtenue { get; set; }

        /*public List<GridViewModel> Buletins()
        {
            List<GridViewModel> list = new List<GridViewModel>();
            using (EcoleContext context = new EcoleContext())
            {
                foreach (Etudiant e in context.Etudiants)
                {
                    list.Add(new GridViewModel() { ID = e.Id, nom = e.Nom, prenom = e.Prenom });

                }

                return list;
            }
            
        }*/
    }
}