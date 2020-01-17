namespace Design.Migrations
{
    using Design.Context;
    using Design.Model;
    using System;
    using System.Collections.Generic;
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
                c1, c2, c3, c4, c5
            );
            var g1 = new Game() { Name = "Ori and the blind forest: definitive edition", Amount = 150, Publisher = "Microsoft Studios", Detail = "", Category = c1, PurchaseCost = 60000, SaleCost = 100000 };
            var g2 = new Game() { Name = "Nier automata", Amount = 49, Publisher = "Square Enix", Detail = "", Category = c4, PurchaseCost = 800000, SaleCost = 1250000 };
            var g3 = new Game() { Name = "Life is Strange", Amount = 100, Publisher = "Square Enix", Detail = "", Category = c5, PurchaseCost = 50000, SaleCost = 80000 };
            var g4 = new Game() { Name = "Grand Theft Auto V", Amount = 145, Publisher = "Rockstar Games", Detail = "", Category = c3, PurchaseCost = 200000, SaleCost = 220000 };
            var g5 = new Game() { Name = "Mega Man 11", Amount = 99, Publisher = "CAPCOM", Detail = "", Category = c1, PurchaseCost = 310000, SaleCost = 340000 };
            var g6 = new Game() { Name = "Cities: Skylines", Amount = 99, Publisher = "Paradox Interactive", Detail = "", Category = c5, PurchaseCost = 700000, SaleCost = 120000 };
            var g7 = new Game() { Name = "MINECRAFT", Amount = 99, Publisher = "Microsoft Studios", Detail = "", Category = c2, PurchaseCost = 600000, SaleCost = 700000 };
            var g8 = new Game() { Name = "Mark of the Ninja", Amount = 25, Publisher = "Microsoft Studios", Detail = "", Category = c3, PurchaseCost = 140000, SaleCost = 180000 };
            var g9 = new Game() { Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", Amount = 251, Publisher = "PUBG Corporation", Detail = "", Category = c2, PurchaseCost = 200000, SaleCost = 340000 };
            var g10 = new Game() { Name = "Far Cry® 5", Amount = 249, Publisher = "Ubisoft", Detail = "", Category = c3, PurchaseCost = 400000, SaleCost = 600000 };
            var g11 = new Game() { Name = "Assassin's Creed® Odyssey", Amount = 232, Publisher = "Ubisoft", Detail = "", Category = c2, PurchaseCost = 500000, SaleCost = 800000 };
            var g12 = new Game() { Name = "Stardew Valley", Amount = 132, Publisher = "ConcernedApe", Detail = "", Category = c2, PurchaseCost = 150000, SaleCost = 165000 };


            context.games.AddOrUpdate(g => g.Id, g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12);
            context.transactions.AddOrUpdate(t => t.Id,
                new Transaction() { Name = "t1", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 200000 },
                new Transaction() { Name = "t2", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 1 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 12, 1), paymentAmount = 100000 },
                new Transaction() { Name = "t3", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 6 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 12, 1), paymentAmount = 10000 },
                new Transaction() { Name = "t4", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 6 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 3, 1), paymentAmount = 10000 },
                new Transaction() { Name = "t5", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 6 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 3, 1), paymentAmount = 100000 },
                new Transaction() { Name = "t6", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 4, 1), paymentAmount = 2342341 },
                new Transaction() { Name = "t7", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 4, 1), paymentAmount = 2342341 },
                new Transaction() { Name = "t8", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 150000 },
                new Transaction() { Name = "t9", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 150000 },
                new Transaction() { Name = "t10", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 5, 1), paymentAmount = 900000 },
                new Transaction() { Name = "t11", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 5, 1), paymentAmount = 900000 },
                new Transaction() { Name = "t12", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 5, 1), paymentAmount = 900000 },
                new Transaction() { Name = "t13", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 5, 1), paymentAmount = 900000 },
                new Transaction() { Name = "t14", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 5, 1), paymentAmount = 710000 },
                new Transaction() { Name = "t15", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g11, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 140000 },
                new Transaction() { Name = "t16", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g11, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 140000 },
                new Transaction() { Name = "t17", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 6, 1), paymentAmount = 230000 },
                new Transaction() { Name = "t18", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 6, 1), paymentAmount = 230000 },
                new Transaction() { Name = "t19", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 6, 1), paymentAmount = 230000 },
                new Transaction() { Name = "t20", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 970000 },
                new Transaction() { Name = "t21", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 16 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 7, 1), paymentAmount = 970000 },
                new Transaction() { Name = "t22", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 16 }, new GameInTran() { Name = "gt2", Game = g8, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 7, 1), paymentAmount = 970000 },
                new Transaction() { Name = "t23", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 16 }, new GameInTran() { Name = "gt2", Game = g8, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 7, 1), paymentAmount = 970000 },
                new Transaction() { Name = "t24", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g8, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 7, 1), paymentAmount = 970000 },
                new Transaction() { Name = "t25", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g8, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 130000 },
                new Transaction() { Name = "t26", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 8, 1), paymentAmount = 92000 },
                new Transaction() { Name = "t27", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 8, 1), paymentAmount = 92000 },
                new Transaction() { Name = "t28", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 7 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g9, Amount = 3 } }, DateOfTrans = new DateTime(2020, 8, 1), paymentAmount = 92000 },
                new Transaction() { Name = "t29", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 120000 },
                new Transaction() { Name = "t30", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 120000 },
                new Transaction() { Name = "t31", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 132000 },
                new Transaction() { Name = "t32", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 9, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t33", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 9, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t34", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 4 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 9, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t35", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 9, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t36", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 5 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 9, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t37", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 5 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 250000 },
                new Transaction() { Name = "t38", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 5 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 540000 },
                new Transaction() { Name = "t39", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 5 }, new GameInTran() { Name = "gt2", Game = g4, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g10, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 540000 },
                new Transaction() { Name = "t40", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 540000 },
                new Transaction() { Name = "t41", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 320000 },
                new Transaction() { Name = "t42", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g11, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 320000 },
                new Transaction() { Name = "t43", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g11, Amount = 3 } }, DateOfTrans = new DateTime(2020, 10, 1), paymentAmount = 320000 },
                new Transaction() { Name = "t44", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g5, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g11, Amount = 3 } }, DateOfTrans = new DateTime(2020, 2, 1), paymentAmount = 930000 },
                new Transaction() { Name = "t45", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 12 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 1, 1), paymentAmount = 930000 },
                new Transaction() { Name = "t46", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 20 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 4, 1), paymentAmount = 780000 },
                new Transaction() { Name = "t47", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 20 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 4, 1), paymentAmount = 780000 },
                new Transaction() { Name = "t48", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 20 }, new GameInTran() { Name = "gt2", Game = g7, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g12, Amount = 3 } }, DateOfTrans = new DateTime(2020, 4, 1), paymentAmount = 780000 },
                new Transaction() { Name = "t49", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 9 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 8, 1), paymentAmount = 650000 },
                new Transaction() { Name = "t50", Games = new List<GameInTran> { new GameInTran() { Name = "gt1", Game = g1, Amount = 15 }, new GameInTran() { Name = "gt2", Game = g2, Amount = 1 }, new GameInTran() { Name = "gt3", Game = g3, Amount = 3 } }, DateOfTrans = new DateTime(2020, 2, 1), paymentAmount = 431000 }


                );
        }
    }
}
