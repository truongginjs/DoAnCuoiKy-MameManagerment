using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Adapter;
using Design.Model;
using Design.Context;

namespace Design.ViewModel.Statistics
{
    public class LineViewModel: BaseViewModel
    {
        public SeriesCollection PaymentSeriesCollection { get; set; }
        public string[] PaymentLabels { get; set; }
        public Func<double, string> PaymentFormatter { get; set; }

        public SeriesCollection AmountSeriesCollection { get; set; }
        public string[] AmountLabels { get; set; }
        public Func<double, string> AmountFormatter { get; set; }
        LineStatistic lineStatistic;

        public LineViewModel()
        {
            List<Transaction> data = Common.Instance.transactions.ToList<Transaction>();
            lineStatistic = new LineStatistic(data);
            //bieu do 1

            PaymentFormatter = GetFormatter();
            PaymentLabels = GetLabel();

            PaymentSeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "doanh thu",

                    Values =GetlistData(),

                    //DataLabels = true,

                },

            };
            //bieu do 2
            AmountFormatter = GetFormatter();
            AmountLabels = GetLabel();
            AmountSeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "doanh thu",

                    Values =GetlistData(),

                    //DataLabels = true,

                },

            };
        }

        private IChartValues GetlistData()
        {
            return lineStatistic.GetListValue();
        }

        private string[] GetLabel()
        {
            return lineStatistic.GetLabels().ToArray();
        }
        private Func<double, string> GetFormatter()
        {
            return lineStatistic.GetFormatter();
        }
    }
}
