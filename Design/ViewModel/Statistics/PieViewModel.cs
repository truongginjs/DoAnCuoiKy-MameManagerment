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
        public Func<ChartPoint, string> PaymentPointLabel { get; set; }

        public SeriesCollection AmountSeriesCollection { get; set; }
        public Func<ChartPoint, string> AmountPointLabel { get; set; }
        public PieViewModel()
        {
            //chart 1
            PaymentPointLabel = chartPoint =>
                string.Format("({1:P})", chartPoint.Y, chartPoint.Participation);

            List<double> PaymentlistData = GetListData();
            List<string> PaymentlsitLabel = GetLabel();
            PaymentSeriesCollection = new SeriesCollection();

            int i = 0;
            foreach (var item in PaymentlistData)
            {
                PaymentSeriesCollection.Add(new PieSeries { Title = PaymentlsitLabel[i], Values = new ChartValues<int> { (int)item }, DataLabels = true, LabelPoint = PaymentPointLabel });

                i++;
            }

            //chart 2
            AmountPointLabel = chartPoint =>
               string.Format("({1:P})", chartPoint.Y, chartPoint.Participation);

            List<double> AmountlistData = GetListData();
            List<string> AmountlsitLabel = GetLabel();
            PaymentSeriesCollection = new SeriesCollection();

            i = 0;
            foreach (var item in AmountlistData)
            {
                PaymentSeriesCollection.Add(new PieSeries { Title = AmountlsitLabel[i], Values = new ChartValues<int> { (int)item }, DataLabels = true, LabelPoint = AmountPointLabel });

                i++;
            }
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
