using System.Data.Entity.Migrations;

namespace Game.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Game.EntityFramework.GameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Game";
        }

        protected override void Seed(Game.EntityFramework.GameDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
