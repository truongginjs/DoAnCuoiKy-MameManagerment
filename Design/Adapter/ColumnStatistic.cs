using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Context;
using Design.Model;
using LiveCharts;
using LiveCharts.Wpf;

namespace Design.Adapter
{
    public class ColumnStatistic : Statistic
    {
        private Dictionary<Game, int> games = new Dictionary<Game, int>();

        public ColumnStatistic(List<Transaction> Data) : base(Data)
        {
            Data.ForEach(t => t.Games.ToList().ForEach(g =>
            {
                if (games.ContainsKey(g.Game))
                {
                    games[g.Game] += g.Amount;
                }
                else
                {
                    games.Add(g.Game, g.Amount);
                }
            }));
        }
        public ColumnStatistic(Request request): base(request)
        {
            Data.ForEach(t => t.Games.ToList().ForEach(g =>
            {
                if (games.ContainsKey(g.Game))
                {
                    games[g.Game] += g.Amount;
                }
                else
                {
                    games.Add(g.Game, g.Amount);
                }
            }));
        }

        public override string[] GetLabels()
        {
            
            List<string> list = new List<string>();
            foreach (var game in games)
            {
                list.Add(game.Key.Name);
            }
            return list.ToArray();
        }

        public override SeriesCollection GetListValue()
        {
            SeriesCollection seriesCollection;
            if (request is AmountRequest)
            {
                seriesCollection = new SeriesCollection
                {
                    new StackedColumnSeries
                    {
                        Title = "Đã bán",

                        Values = getSaled(),
                        StackMode = StackMode.Values,
                        DataLabels = true
                    },
                    new StackedColumnSeries
                    {
                        Title = "Còn lại",

                        Values = getInStore(),
                        StackMode = StackMode.Values,
                        DataLabels = true
                    },
                };
                return seriesCollection;
            }
            seriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Đã bán",
                    Values = getSaledPayment(),
                    StackMode = StackMode.Values,
                    DataLabels = true,
                   
                },
               
            };
            return seriesCollection;
        }

        private IChartValues getSaledPayment()
        {
            var result = new ChartValues<long>();
            Data.ForEach(t => result.Add(t.paymentAmount));
            return result;
        }

        private IChartValues getInStore()
        {
            var result = new ChartValues<long>();
            foreach(var game in games)
            {
                result.Add(game.Key.Amount - game.Value);
            }
            return result;
        }

        private IChartValues getSaled()
        {
            var result = new ChartValues<long>();
            foreach (var game in games)
            {
                result.Add(game.Value);
            }
            return result;
        }
    }
}
