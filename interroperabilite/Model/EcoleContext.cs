namespace interroperabilite.Model
{
    using interroperabilite.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EcoleContext : DbContext
    {
        

        public EcoleContext() : base("name=Model1")
        {
            Database.SetInitializer<EcoleContext>(new DropCreateDatabaseAlways<EcoleContext>());// DropCreateDatabaseIfModelChanges<EcoleContext>());//new CreateDatabaseIfNotExists<EcoleContext>());
            
        }
        public virtual DbSet<Etudiant> Etudiants { get; set; }
        public virtual DbSet<Matiere> Matieres { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        
    }
}