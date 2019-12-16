namespace Design.Migrations
{
    using Design.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Design.Context.ShopGameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Design.Context.ShopGameContext context)
        {
            context.humen.AddOrUpdate(h => h.id,
                new Human() { name = "A", dateOfBirth = DateTime.Parse("1/1/1998") },
                new Human() { name = "B", dateOfBirth = DateTime.Parse("2/2/1999") },
                new Human() { name = "C", dateOfBirth = DateTime.Parse("3/3/1999") }
            );
        }
    }
}
