using Design.Adapter;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.ViewModel.Statistics
{
    public class PieViewModel: BaseViewModel
    {
        public SeriesCollection PaymentSeriesCollection { get; set; }


        public SeriesCollection AmountSeriesCollection { get; set; }
        public PieViewModel()
        {
            //chart 1

            var pieStatistic = new PieStatistic(new AmountRequest());
            AmountSeriesCollection = pieStatistic.GetListValue();

            //chart 2
            pieStatistic= new PieStatistic(new PaymentRequest());
            PaymentSeriesCollection = pieStatistic.GetListValue();
        }

        private List<string> GetLabel()
        {
            throw new NotImplementedException();
        }

        private List<double> GetListData()
        {
            throw new NotImplementedException();
        }
    }
}
