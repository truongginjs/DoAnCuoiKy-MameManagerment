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

        public SeriesCollection AmountSeriesCollection { get; set; }
        public string[] AmountLabels { get; set; }
        

        public LineViewModel()
        {

            LineStatistic lineStatistic = new LineStatistic(new PaymentRequest());
            //bieu do 1

            PaymentLabels = lineStatistic.GetLabels();

            PaymentSeriesCollection = lineStatistic.GetListValue();
            //bieu do 2
            lineStatistic = new LineStatistic(new AmountRequest());
            AmountLabels = lineStatistic.GetLabels();
            AmountSeriesCollection = lineStatistic.GetListValue();
        }
    }
}
