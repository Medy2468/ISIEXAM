namespace ISIEXAM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ISIEXAM.Models.bdISIEXAMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Au cas où on met à false, la base de donnée ne sera pas créée.
            AutomaticMigrationDataLossAllowed = false; // En cas de perte de donnée un message sera envoyé pour indiquer l'erreur.
        }

        protected override void Seed(ISIEXAM.Models.bdISIEXAMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
