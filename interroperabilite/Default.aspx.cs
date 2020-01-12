using interroperabilite.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace interroperabilite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccessLayer dal = new DataAccessLayer();

            Notes.DataSource = dal.Bulletins();
            Notes.HeaderStyle.BackColor = Color.Blue;
            Notes.HeaderStyle.ForeColor = Color.White;
            Notes.HeaderStyle.Width = 100;
            
            Notes.DataBind();

        }

        protected void LoadFromExcel_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider= Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|notes_etudiants.xls; Extended Properties=Excel 8.0");

            connection.Open();
            DataTable datatable;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet dataset;
            //Obtenir le Schema du fichier Excel
            datatable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string nomFeuilleExcel = datatable.Rows[0][2].ToString();
            OleDbCommand commandSelection = new OleDbCommand("SELECT * FROM [" + nomFeuilleExcel + "]", connection);
            // Créér un adaptateur pour récupérer les valeurs des cellules Excel

            OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter();
            // transfert des données depuis le fichier Execl vers l'adaptateur
            oleDataAdapter.SelectCommand = commandSelection;

            dataset = new DataSet();
            // remplir le Data Set avec le contenu de l'adaptateur
            oleDataAdapter.Fill(dataset);
            List<Matiere> matieres = new List<Matiere>();
            for (int i = 3; i < dataset.Tables[0].Columns.Count - 1; i++)
            {
                var ligneCoeff = dataset.Tables[0].Rows[1].ItemArray;
                matieres.Add(new Matiere() { Id=i-2, Libelle = dataset.Tables[0].Columns[i].Caption, Coef = int.Parse(ligneCoeff[i].ToString()) });

            }
            EcoleContext context = new EcoleContext();
            context.Matieres.AddRange(matieres);
            context.SaveChanges();
            
            List<Etudiant> etudiants = new List<Etudiant>();
            List<Note> notes = new List<Note>();
            for (int j = 2; j < dataset.Tables[0].Rows.Count; j++)
            {
                var tab = dataset.Tables[0].Rows[j].ItemArray;
                etudiants.Add(new Etudiant() {
                    Id = int.Parse(tab[0].ToString()),
                    Nom = tab[1].ToString(),
                    Prenom = tab[2].ToString()
                });

                for (int k = 3; k < tab.Length - 1; k++)
                {
                    notes.Add(new Note() {
                        Id = j - 1,
                        Idetudiant = etudiants[j - 2].Id,
                        Idmatiere = matieres.ElementAt(k-3).Id,
                        NoteObtenue = float.Parse(tab[k].ToString()) });
                }
                
            }
            context.Etudiants.AddRange(etudiants);
            //context.Etudiants.Add(new Etudiant() { Id = 1, Nom = "", Prenom = "1123" });
            context.Notes.AddRange(notes);
            context.SaveChanges();
            context.Dispose();
            connection.Close();
            Response.Redirect("/");
        }
    }
}