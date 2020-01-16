using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public LineViewModel()
        {
            //bieu do 1
            PaymentFormatter = value => value.ToString();
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
            AmountFormatter = value => value.ToString();
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
            throw new NotImplementedException();
        }

        private string[] GetLabel()
        {
            throw new NotImplementedException();
        }
    }
}
