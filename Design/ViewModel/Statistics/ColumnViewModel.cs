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
using Design.Adapter;
using Design.Model;

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
        ColumnStatistic columnStatistic;

        public ColumnViewModel()
        {
            var beginDate = DateTime.Now;
            var endDate = DateTime.Now;
            List<Transaction> data =Common.Instance.transactions.ToList<Transaction>(); 
            columnStatistic = new ColumnStatistic(data);
            
            //var data = Common.Instance.transactions.Where(t => t.DateOfTrans <= endDate && t.DateOfTrans >= beginDate);
            //bieu do 1
            PaymentFormatter = columnStatistic.GetFormatter();
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
            AmountFormatter = columnStatistic.GetFormatter();
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

        private List<String> GetLabels(List<Transaction> data)
        {
            return columnStatistic.GetLabels();
        }

        private IChartValues GameInStore(List<Transaction> data)
        {
            //ghi tạm thời
            return columnStatistic.GetListValue();
        }

        private IChartValues GameSaled(List<Transaction> data)
        {
            //ghi tạm thời
            return columnStatistic.GetListValue();
        }
    }
}
