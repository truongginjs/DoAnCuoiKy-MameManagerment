namespace Design.Migrations
{
    using Design.Context;
    using Design.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopGameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopGameContext context)
        {
            var c1 = new Category() { Name = "Platform" };
            var c2 = new Category() { Name = "Advanture" };
            var c3 = new Category() { Name = "Action" };
            var c4 = new Category() { Name = "Fantasy" };
            var c5 = new Category() { Name = "Simulator" };
            context.categories.AddOrUpdate(c => c.Id,
                c1,c2,c3,c4,c5
            );

            context.games.AddOrUpdate(g => g.Id,
                new Game() { Name = "Ori and the blind forest: definitive edition", Amount = 150, Publisher = "Microsoft Studios", Detail = "", Category = c1 , PurchaseCost = 60000, SaleCost = 100000 },
                new Game() { Name = "Nier automata", Amount = 49, Publisher = "Square Enix", Detail = "", Category=c4, PurchaseCost = 800000, SaleCost = 1250000 },
                new Game() { Name = "Life is Strange", Amount = 100, Publisher = "Square Enix", Detail = "", Category=c5, PurchaseCost = 50000, SaleCost = 80000 },
                new Game() { Name = "Grand Theft Auto V", Amount = 145, Publisher = "Rockstar Games", Detail = "", Category=c3, PurchaseCost = 200000, SaleCost = 220000 },
                new Game() { Name = "Mega Man 11", Amount = 99, Publisher = "CAPCOM", Detail = "", Category=c1, PurchaseCost = 310000, SaleCost = 340000 },
                new Game() { Name = "Cities: Skylines", Amount = 99, Publisher = "Paradox Interactive", Detail = "", Category=c5, PurchaseCost = 700000, SaleCost = 120000 },
                new Game() { Name = "MINECRAFT", Amount = 99, Publisher = "Microsoft Studios", Detail = "", Category=c2, PurchaseCost = 600000, SaleCost = 700000 },
                new Game() { Name = "Mark of the Ninja", Amount = 25, Publisher = "Microsoft Studios", Detail = "", Category=c3, PurchaseCost = 140000, SaleCost = 180000 },
                new Game() { Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", Amount = 251, Publisher = "PUBG Corporation", Detail = "", Category=c2, PurchaseCost = 200000, SaleCost = 340000 },
                new Game() { Name = "Far Cry® 5", Amount = 249, Publisher = "Ubisoft", Detail = "", Category=c3, PurchaseCost = 400000, SaleCost = 600000 },
                new Game() { Name = "Assassin's Creed® Odyssey", Amount = 232, Publisher = "Ubisoft", Detail = "", Category=c2, PurchaseCost = 500000, SaleCost = 800000 },
                new Game() { Name = "Stardew Valley", Amount = 132, Publisher = "ConcernedApe", Detail = "", Category=c2, PurchaseCost = 150000, SaleCost = 165000 }
          );
        }
    }
}
