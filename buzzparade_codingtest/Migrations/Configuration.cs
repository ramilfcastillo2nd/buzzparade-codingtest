using buzzparade_codingtest.Data;
using System.Data.Entity.Migrations;

namespace buzzparade_codingtest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurveyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            SeedData.Initialize(context);
        }
    }
}
