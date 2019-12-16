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
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.OleDb;
using System.Data;

namespace Design
{
    /// <summary>
    /// Interaction logic for DrawPieChart.xaml
    /// </summary>
    public partial class DrawPieChart : UserControl
    {
        private DataProvider dp = new DataProvider();
        private DataProvider dp1 = new DataProvider();

        private DateTime begin;
        private DateTime ends;

        public DrawPieChart(DatePicker _begin, DatePicker _ends)
        { 
            InitializeComponent();
            begin = _begin.SelectedDate.Value.Date;
            ends = _ends.SelectedDate.Value.Date;
            PointLabel = chartPoint =>
                string.Format("({1:P})", chartPoint.Y, chartPoint.Participation);

            PointLabel1 = chartPoint =>
               string.Format("({1:P})", chartPoint.Y, chartPoint.Participation);

            BindGrid();

            List<double> list = dp.Get().AsEnumerable().Select(r => r.Field<double>("sAmount")).ToList();

            List<string> list1 = dp.Get().AsEnumerable().Select(r => r.Field<string>("Name")).ToList();

            List<double> list2 = dp1.Get().AsEnumerable().Select(r => r.Field<double>("STotal")).ToList();
            List<string> list3 = dp1.Get().AsEnumerable().Select(r => r.Field<string>("Name")).ToList();

            //MessageBox.Show("" + list[0] + list[1] + list[2]);


            seriesCollection = new SeriesCollection();

            int i = 0;
            foreach (var item in list)
            {
                seriesCollection.Add(new PieSeries { Title = list1[i], Values = new ChartValues<int> { (int)item }, DataLabels = true, LabelPoint = PointLabel, });

                i++;
            }

            seriesCollection1 = new SeriesCollection();

            i = 0;
            foreach (var item in list2)
            {
                seriesCollection1.Add(new PieSeries { Title = list3[i], Values = new ChartValues<int> { (int)item }, DataLabels = true, LabelPoint = PointLabel1 });
                i++;
            }

            DataContext = this;
        }
        public SeriesCollection seriesCollection { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public SeriesCollection seriesCollection1 { get; set; }
        public Func<ChartPoint, string> PointLabel1 { get; set; }


        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            //MessageBox.Show("lala");
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        private void BindGrid()
        {
            if (begin < ends && ends <= DateTime.Now)
            {
                string s1 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sAmount from Product left join Trans on Product.ID=Trans.IDGame Where Trans.Dated >= #{begin.ToString()}# and Trans.Dated <= #{ends.ToString()}# group by Product.Name";
                string s2 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Total), 0, Trans.Total)) as sTotal from Product left join Trans on Product.ID=Trans.IDGame Where Trans.Dated >= #{begin.ToString()}# and Trans.Dated <= #{ends.ToString()}#  group by Product.Name";
                dp.withQuery(s1);
                dp1.withQuery(s2);

            }
            else
            {
                string s1 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sAmount from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name";
                string s2 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Total), 0, Trans.Total)) as sTotal from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name";

                dp.withQuery(s1);
                dp1.withQuery(s2);
            }

        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            //MessageBox.Show("lala");
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
