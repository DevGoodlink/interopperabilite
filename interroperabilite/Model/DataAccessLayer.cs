using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace interroperabilite.Model
{
    public class DataAccessLayer
    {
        EcoleContext context;
        public DataAccessLayer()
        {
            context = new EcoleContext();
        }

        public void AjouterEtudiant(int id, string Nom, string Prenom)
        {
            Etudiant Etudiant = new Etudiant() { Id = id,Nom = Nom,Prenom=Prenom };
            context.Etudiants.Add(Etudiant);
            context.SaveChanges();
           
        }
        public void AjouterMatiere(int Id, int Coef, string Libelle)
        {
            Matiere Matiere = new Matiere() {Id=Id,Coef=Coef,Libelle=Libelle };
            context.Matieres.Add(Matiere);
            context.SaveChanges();
        }
        public void AjouterNote(int idMatiere, int idEtudiant, double note, int annee)
        {
            Note Note = new Note();
            context.Notes.Add(Note);
            context.SaveChanges();
        }

        public void UpdateEtudiant(Etudiant Etudiant)
        {
            //TODO à définir

        }
        public DataSet Bulletins()
        {
            List<GridViewModel> list = new List<GridViewModel>();
            
            foreach (Etudiant e in context.Etudiants)
            {
                float somme = 0;
                int sommecoef = 0;
                var query = from n in context.Notes where n.Idetudiant == e.Id select n;
                List<Note> notes = query.ToList<Note>();

                foreach(Note n in notes)
                {
                    Matiere matiere = (from m in context.Matieres where m.Id == n.Idmatiere select m).First<Matiere>();
                    somme += n.NoteObtenue * matiere.Coef;
                    sommecoef += matiere.Coef;
                }
                float noteFinal = somme / sommecoef;
                list.Add(new GridViewModel() { ID = e.Id, nom = e.Nom, prenom = e.Prenom, note= noteFinal });

            }

            return Helper.ToDataSet(list);
        }
        
    }
}