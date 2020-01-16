using Design.Context;
using Design.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Design.ViewModel.Statistics
{
    public class ColumnViewModel : BaseViewModel
    {
        public SeriesCollection PaymentSeriesCollection { get; set; }
        public string[] PaymentLabels { get; set; }
        public Func<double, string> PaymentFormatter { get; set; }
        HashSet<Game> games = new HashSet<Game>();

        public SeriesCollection AmountSeriesCollection { get; set; }
        public string[] AmountLabels { get; set; }
        public Func<double, string> AmountFormatter { get; set; }

        public ColumnViewModel()
        {
            var beginDate = DateTime.Now;
            var endDate = DateTime.Now;
            var data = Common.Instance.transactions.Where(t => t.DateOfTrans <= endDate && t.DateOfTrans >= beginDate);
            //bieu do 1
            PaymentFormatter = value => value.ToString();
            PaymentLabels = GetLabels(data).ToArray();

            PaymentSeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Đã bán",

                    Values = GameSaled(data),
                        StackMode = StackMode.Values,
                        DataLabels = true,

                },
                new StackedColumnSeries
                {
                    Title = "Còn lại",

                    Values = GameInStore(data),
                        StackMode = StackMode.Values,
                        DataLabels = true
                }
            };
            //bieu do 2
            AmountFormatter = value => value.ToString();
            AmountLabels = GetLabels(data).ToArray();

            AmountSeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Đã bán",

                    Values = GameSaled(data),
                        StackMode = StackMode.Values,
                        DataLabels = true,

                },
                new StackedColumnSeries
                {
                    Title = "Còn lại",

                    Values = GameInStore(data),
                        StackMode = StackMode.Values,
                        DataLabels = true
                }
            };
        }

        private List<String> GetLabels(IQueryable<Model.Transaction> data)
        {
            
            data.ToList().ForEach(t => t.Games.ToList().ForEach(g => games.Add(g.Game)));
            var list = new List<string>();
            foreach (Game game in games)
            {
                list.Add(game.Name);
            }
            return list;
        }

        private IChartValues GameInStore(IQueryable<Model.Transaction> data)
        {
            throw new NotImplementedException();
        }

        private IChartValues GameSaled(IQueryable<Model.Transaction> data)
        {
            throw new NotImplementedException();
        }
    }
}
