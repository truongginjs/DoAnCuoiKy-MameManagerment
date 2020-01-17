using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Model;
using LiveCharts;

namespace Design.Adapter
{
    public class ColumnStatistic : Statistic
    {
        public ColumnStatistic(List<Transaction> Data) : base(Data)
        {
        }

        public override Func<double, string> GetFormatter()
        {
            return value => value.ToString();
        }

        public override List<string> GetLabels()
        {
            HashSet<Game> games = new HashSet<Game>();
            Data.ForEach(t => t.Games.ToList().ForEach(g => games.Add(g.Game)));
            List<string> list = new List<string>();
            foreach (Game game in games)
            {
                list.Add(game.Name);
            }
            return list;
        }

        public override ChartValues<double> GetListValue()
        {
            List<double> moneyList = new List<double>();
            Data.ForEach(t => moneyList.Add(t.paymentAmount));
            return new ChartValues<double>(moneyList);
        }
    }
}
