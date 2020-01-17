using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Model;
using LiveCharts;
using LiveCharts.Wpf;

namespace Design.Adapter
{
    public class PieStatistic: Statistic
    {
        public Dictionary<Game, int> games { get; set; } = new Dictionary<Game, int>();

        public PieStatistic(List<Transaction> Data) : base(Data)
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
        public PieStatistic(Request request) : base(request)
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
            Func<ChartPoint, string> PaymentPointLabel = chartPoint => string.Format("({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection seriesCollection = new SeriesCollection();
            if (request is AmountRequest)
            {
                foreach(var g in games)
                {
                    seriesCollection.Add(new PieSeries { Title = g.Key.Name, Values = new ChartValues<long> { g.Value }, DataLabels = false, LabelPoint = chartPoint =>
                    string.Format("({1:P})", chartPoint.Y, chartPoint.Participation) });
                }
            }
            else
            {
                foreach (var g in games)
                {
                    seriesCollection.Add(new PieSeries { Title = g.Key.Name, Values = new ChartValues<long> { g.Value }, DataLabels = false, LabelPoint = chartPoint =>
                    string.Format("({1:P})", chartPoint.Y, chartPoint.Participation) });
                }
            }
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
            foreach (var game in games)
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
