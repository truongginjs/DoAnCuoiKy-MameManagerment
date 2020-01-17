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

namespace Design.ViewModel.Statistics
{
    public class ColumnViewModel : BaseViewModel
    {
        public SeriesCollection PaymentSeriesCollection { get; set; }
        public string[] PaymentLabels { get; set; }

        public SeriesCollection AmountSeriesCollection { get; set; }
        public string[] AmountLabels { get; set; }


        public ColumnViewModel()
        {
            var beginDate = DateTime.Now;
            var endDate = DateTime.Now;
            ColumnStatistic columnStatistic = new ColumnStatistic(new PaymentRequest());
            
            //bieu do 1
            PaymentLabels = columnStatistic.GetLabels();
            PaymentSeriesCollection = columnStatistic.GetListValue();

            //bieu do 2
            columnStatistic = new ColumnStatistic(new AmountRequest());
            AmountLabels = columnStatistic.GetLabels();
            AmountSeriesCollection = columnStatistic.GetListValue();
        }
    }
}
