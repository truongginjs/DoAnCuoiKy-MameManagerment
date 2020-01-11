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
            context.humen.AddOrUpdate(h => h.id,
                new Human() { name = "A", dateOfBirth = DateTime.Parse("1/1/1998") },
                new Human() { name = "B", dateOfBirth = DateTime.Parse("2/2/1999") },
                new Human() { name = "C", dateOfBirth = DateTime.Parse("3/3/1999") }
            );

            context.categories.AddOrUpdate(c => c.CategoryId,
                new Category() { name = "Platform" },
                new Category() { name = "Advanture" },
                new Category() { name = "Action" },
                new Category() { name = "Fantasy" },
                new Category() { name = "Simulator" }
            );

            context.games.AddOrUpdate(g => g.id,
                new Game() { name = "Ori and the blind forest: definitive edition", amount = 150, publisher = "Microsoft Studios", detail = "", CategoryId =1, purchaseCost = 60000, SaleCost = 100000 },
                new Game() { name = "Nier automata", amount = 49, publisher = "Square Enix", detail = "", CategoryId =4, purchaseCost = 800000, SaleCost = 1250000 },
                new Game() { name = "Life is Strange", amount = 100, publisher = "Square Enix", detail = "", CategoryId =3, purchaseCost = 50000, SaleCost = 80000 },
                new Game() { name = "Grand Theft Auto V", amount = 145, publisher = "Rockstar Games", detail = "", CategoryId =3, purchaseCost = 200000, SaleCost = 220000 },
                new Game() { name = "Mega Man 11", amount = 99, publisher = "CAPCOM", detail = "", CategoryId =1, purchaseCost = 310000, SaleCost = 340000 },
                new Game() { name = "Cities: Skylines", amount = 99, publisher = "Paradox Interactive", detail = "", CategoryId =3, purchaseCost = 700000, SaleCost = 120000 },
                new Game() { name = "MINECRAFT", amount = 99, publisher = "Microsoft Studios", detail = "", CategoryId =1, purchaseCost = 600000, SaleCost = 700000 },
                new Game() { name = "Mark of the Ninja", amount = 25, publisher = "Microsoft Studios", detail = "", CategoryId =4, purchaseCost = 140000, SaleCost = 180000 },
                new Game() { name = "PLAYERUNKNOWN'S BATTLEGROUNDS", amount = 251, publisher = "PUBG Corporation", detail = "", CategoryId =2, purchaseCost = 200000, SaleCost = 340000 },
                new Game() { name = "Far Cry® 5", amount = 249, publisher = "Ubisoft", detail = "", CategoryId =1, purchaseCost = 400000, SaleCost = 600000 },
                new Game() { name = "Assassin's Creed® Odyssey", amount = 232, publisher = "Ubisoft", detail = "", CategoryId =4, purchaseCost = 500000, SaleCost = 800000 },
                new Game() { name = "Stardew Valley", amount = 132, publisher = "ConcernedApe", detail = "", CategoryId =5, purchaseCost = 150000, SaleCost = 165000 }
          );
        }
    }
}

//context.games.AddOrUpdate(g => g.id,
                //new Game() { name = "Ori and the blind forest: definitive edition", amount = 150, publisher = "Microsoft Studios", detail = "", CategoryId =1, purchaseCost = 60000, SaleCost = 100000 },
                //new Game() { name = "Nier automata", amount = 49, publisher = "Square Enix", detail = "", CategoryId =Fantasy" }, purchaseCost = 800000, SaleCost = 1250000 },
                //new Game() { name = "Life is Strange", amount = 100, publisher = "Square Enix", detail = "", CategoryId =Advanture" }, purchaseCost = 50000, SaleCost = 80000 },
                //new Game() { name = "Grand Theft Auto V", amount = 145, publisher = "Rockstar Games", detail = "", CategoryId =Action" }, purchaseCost = 200000, SaleCost = 220000 },
                //new Game() { name = "Mega Man 11", amount = 99, publisher = "CAPCOM", detail = "", CategoryId =1, purchaseCost = 310000, SaleCost = 340000 },
                //new Game() { name = "Cities: Skylines", amount = 99, publisher = "Paradox Interactive", detail = "", CategoryId =Simulator" }, purchaseCost = 700000, SaleCost = 120000 },
                //new Game() { name = "MINECRAFT", amount = 99, publisher = "Microsoft Studios", detail = "", CategoryId =Advanture" }, purchaseCost = 600000, SaleCost = 700000 },
                //new Game() { name = "Mark of the Ninja", amount = 25, publisher = "Microsoft Studios", detail = "", CategoryId =Action" }, purchaseCost = 140000, SaleCost = 180000 },
                //new Game() { name = "PLAYERUNKNOWN'S BATTLEGROUNDS", amount = 251, publisher = "PUBG Corporation", detail = "", CategoryId =Advanture" }, purchaseCost = 200000, SaleCost = 340000 },
                //new Game() { name = "Far Cry® 5", amount = 249, publisher = "Ubisoft", detail = "", CategoryId =Action" }, purchaseCost = 400000, SaleCost = 600000 },
                //new Game() { name = "Assassin's Creed® Odyssey", amount = 232, publisher = "Ubisoft", detail = "", CategoryId =Advanture" }, purchaseCost = 500000, SaleCost = 800000 },
                //new Game() { name = "Stardew Valley", amount = 132, publisher = "ConcernedApe", detail = "", CategoryId =Advanture" }, purchaseCost = 150000, SaleCost = 165000 }
