using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace entity_try.Models
{
    public class BddContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<BddContext>(null); //Activer cette ligne pour la version à utiliser en production
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BddContext>());//ligne en développement, réinitialise la BDD à désactiver en production
            base.OnModelCreating(modelBuilder);
        }

    }
}