using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using LiveCharts;
using LiveCharts.Wpf;

namespace Design
{
    /// <summary>
    /// Interaction logic for DrawLineChart.xaml
    /// </summary>
    public partial class DrawLineChart : UserControl
    {
        public DrawLineChart()
        {

            InitializeComponent();
            //    BindGrid();
            //    //chart1
            //    string[] temp1 = dp2.Get().AsEnumerable().Select(r => r.Field<DateTime>("Dated")).Select(r => r.ToString("MM/dd/yyyy")).ToArray();
            //    Labels = temp1;
            //    List<double> list2 = dp2.Get().AsEnumerable().Select(r => r.Field<double>("sums")).ToList();

            //    Formatter = value => value.ToString();

            //    SeriesCollection = new SeriesCollection
            //    {

            //        new LineSeries
            //        {
            //            Title = "doanh thu",

            //            Values =new ChartValues<double>(list2),

            //            //DataLabels = true,

            //        },

            //    };
            //    //chart2
            //    string[] temp2 = dp3.Get().AsEnumerable().Select(r => r.Field<DateTime>("Dated")).Select(r => r.ToString("MM/dd/yyyy")).ToArray();
            //    Labels1 = temp2;
            //    List<double> list3 = dp3.Get().AsEnumerable().Select(r => r.Field<double>("sums")).ToList();

            //    Formatter = value => value.ToString();

            //    SeriesCollection1 = new SeriesCollection
            //    {

            //        new LineSeries
            //        {
            //            Title = "Hàng hóa",

            //            Values =new ChartValues<double>(list3),

            //            //DataLabels = true,

            //        },

            //    };
            //}

            //public SeriesCollection SeriesCollection { get; set; }
            //public string[] Labels { get; set; }
            //public Func<double, string> Formatter { get; set; }

            //public SeriesCollection SeriesCollection1 { get; set; }
            //public string[] Labels1 { get; set; }
            //public Func<double, string> Formatter1 { get; set; }
            //private void BindGrid()
            //{
            //    dp2.withQuery("select Trans.Dated as Dated, sum(Total) as SUMS  from Trans GROUP BY Trans.Dated");
            //    dp3.withQuery("select Trans.Dated as Dated, sum(Amount) as SUMS  from Trans GROUP BY Trans.Dated");
        }
    }
}
