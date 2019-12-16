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
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Data.OleDb;
using System.Data;

namespace Design
{
    /// <summary>
    /// Interaction logic for StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : UserControl
    {
        DataProvider dp = new DataProvider();
        DataProvider dp1 = new DataProvider();

        DataProvider dp2 = new DataProvider();

        DataProvider dp3 = new DataProvider();

        DataProvider dp4 = new DataProvider();

        public StatisticWindow()
        {

            InitializeComponent();

            dpFromDate.SelectedDate = DateTime.Now;
            
            BindGrid();
            //chart 1
            //List<double> list = dp.Get().AsEnumerable().Select(r => r.Field<double>("Sums")).ToList();
            //List<double> list1 = dp1.Get().AsEnumerable().Select(r => r.Field<double>("Sums")).ToList();
            //string[] temp = dp.Get().AsEnumerable().Select(r => r.Field<string>("NameProduct")).ToArray();
            //Labels = temp;
            //Formatter = value => value.ToString();
            //SeriesCollection = new SeriesCollection
            //{

            //    new StackedColumnSeries
            //    {
            //        Title = "Đã bán",

            //        Values =new ChartValues<double>(list),
            //         StackMode = StackMode.Values,
            //         DataLabels = true,

            //    },
            //    new StackedColumnSeries
            //    {
            //        Title = "Còn lại",

            //        Values =new ChartValues<double>(list1),
            //         StackMode = StackMode.Values,
            //         DataLabels = true
            //    }
            //};
            //chart2
            //string[] temp1 = dp2.Get().AsEnumerable().Select(r => r.Field<DateTime>("Dated")).Select(r => r.ToString("MM/dd/yyyy")).ToArray();
            //Labels2 = temp1;
            //List<double> list2 = dp2.Get().AsEnumerable().Select(r => r.Field<double>("sums")).ToList();
            
            //Formatter2 = value => value.ToString();

            //SeriesCollection2 = new SeriesCollection
            //{

            //    new LineSeries
            //    {
            //        Title = "Tổng doanh thu",

            //        Values =new ChartValues<double>(list2),
                   
            //        //DataLabels = true,

            //    },

            //};
            //Chart 3
            List<int> list3 = dp3.Get().AsEnumerable().Select(r => r.Field<int>("Sums")).ToList();
            List<string> list4 = dp3.Get().AsEnumerable().Select(r => r.Field<string>("NameProduct")).ToList();
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            seriesCollection = new SeriesCollection();
            int i = 0;
            foreach (var item in list3)
            {
                seriesCollection.Add(new PieSeries { Title = list4[i], Values = new ChartValues<int> { (int)item }, DataLabels = true, LabelPoint = PointLabel });
                i++;
            }

            
           
            

           
            DataContext = this;
        }
        //chart 1
        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> Formatter { get; set; }
        //chart 2
        //public SeriesCollection SeriesCollection2 { get; set; }
        //public string[] Labels2 { get; set; }
        //public Func<double, string> Formatter2 { get; set; }
        //char 3
        public SeriesCollection seriesCollection { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void BindGrid()
        {
            
            string c = "select Product.Name as NameProduct,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as Sums from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name";
            //dp.withQuery(c);
            //dp1.withQuery("select NameProduct,(total - sub) as Sums" +
            //    " From (select Product.Name as NameProduct,Product.Amount as total,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sub from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name,Product.Amount) as tableA");
            //select IDGame,sum(Amount) asSumsfrom Trans group by IDGame ,sum(Trans.Amount) asSumsgroup by Product.Name ,ISNULL(Trans.Amount,0)  Sum(IIF(IsNull(Product.Amount), 0, Product.Amount))
            //dp2.withQuery("select Dated, sum(Total) as SUMS  from Trans GROUP BY Dated");
            //"select Dated, sum(Total) as SUMS  from Trans Dated==" + dpDateFrom.SelectedDate.ToString()

            //dp2.withQuery("select Product.Name as Name ,Trans.Dated as Dated, sum(Total) as SUMS  from Product left join Trans on Product.ID = Trans.IDGame GROUP BY Trans.Dated, Product.Name");
            dp3.withQuery("select Name as NameProduct,Amount as Sums from Product");
            //cmd.CommandText = $"select Product.ID as IDProduct,Sum(IIF(IsNull(DataTransaction.Amount), 0, DataTransaction.Amount)) as s from Product left join DataTransaction on Product.ID=DataTransaction.IDProduct Where DataTransaction.DatePayment >= #{fromDate.SelectedDate.ToString()}# and DataTransaction.DatePayment <= #{toDate.SelectedDate.ToString()}# group by Product.ID";

        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            //var r = new Random();
            //foreach (var observable in SeriesCollection2.)
            //{
            //    observable.Value = r.Next(10, 400);
            //}
        }

        private void DpToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DpDateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DrawCharts()
        {
            //if (dpFromDate.SelectedDate != null && dpToDate.SelectedDate != null)
            //{
            //    if (dpFromDate.SelectedDate < dpToDate.SelectedDate && dpToDate.SelectedDate <= DateTime.Now)
            //    {
            //        //chart 1
            //        string c = $"select Product.Name as NameProduct,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as Sums from Product left join Trans on Product.ID=Trans.IDGame where Trans.Dated=>{dpFromDate.SelectedDate} and Trans.Dated<={dpToDate.SelectedDate} group by Product.Name";
            //        dp.withQuery(c);
            //        dp1.withQuery("select NameProduct,(total - sub) as Sums" +
            //            $" From (select Product.Name as NameProduct,Product.Amount as total,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sub from Product left join Trans on Product.ID=Trans.IDGame where Trans.Dated=>{dpFromDate.SelectedDate} and Trans.Dated<={dpToDate.SelectedDate} group by Product.Name,Product.Amount) as tableA");

            //        //Chart2
            //        dp2.withQuery($"select Trans.Dated, sum(Total) as SUMS  from Trans where Trans.Dated=>{dpFromDate.SelectedDate} and Trans.Dated<={dpToDate.SelectedDate} GROUP BY Dated");

            //        //chart3
            //        dp3.withQuery($"select Name, Sum(Trans.Amount) to Sums from Product left join Trans on Trans.IDGame=Product.ID group by Product.Name");
            //        //chart 4
            //        //dp3.withQuery($"select Name, sum(Trans.Total) to Sums from Product left join Trans on Trans.IDGame=Product.ID group by Product.Name");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Bạn vui lòng chọn một ngày hợp lệ (không phải là ngày của tương lai :)) )");
            //    }
            //}

            //BindGrid();

        }

        private void Chart_OnDataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}