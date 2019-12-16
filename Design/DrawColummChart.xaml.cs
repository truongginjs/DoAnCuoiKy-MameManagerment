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
    /// Interaction logic for DrawColummChart.xaml
    /// </summary>
    public partial class DrawColummChart : UserControl
    {
        DataProvider dp = new DataProvider();
        DataProvider dp1 = new DataProvider();

        DataProvider dp2 = new DataProvider();

        private DateTime begin;
        private DateTime ends;

        public DrawColummChart(DatePicker _begin, DatePicker _ends)
        {

            InitializeComponent();
            begin = _begin.SelectedDate.Value.Date;
            ends = _ends.SelectedDate.Value.Date;
            //chart 1
            BindGrid();
            List<double> list = dp.Get().AsEnumerable().Select(r => r.Field<double>("Sums")).ToList();
            List<double> list1 = dp1.Get().AsEnumerable().Select(r => r.Field<double>("Sums")).ToList();
            string[] temp = dp.Get().AsEnumerable().Select(r => r.Field<string>("NameProduct")).ToArray();
            Labels = temp;
            Formatter = value => value.ToString();
            SeriesCollection = new SeriesCollection
            {

                new StackedColumnSeries
                {
                    Title = "Đã bán",

                    Values =new ChartValues<double>(list),
                     StackMode = StackMode.Values,
                     DataLabels = true,

                },
                new StackedColumnSeries
                {
                    Title = "Còn lại",

                    Values =new ChartValues<double>(list1),
                     StackMode = StackMode.Values,
                     DataLabels = true
                }
            };
            //chart 2

            List<double> list2 = dp2.Get().AsEnumerable().Select(r => r.Field<double>("sTotal")).ToList();
            
            string[] temp1 = dp2.Get().AsEnumerable().Select(r => r.Field<string>("Name")).ToArray();
            Labels2 = temp1;
            Formatter2 = value => value.ToString();
            SeriesCollection2 = new SeriesCollection
            {

                new StackedColumnSeries
                {
                    Title = "Đã bán",

                    Values =new ChartValues<double>(list2),
                     StackMode = StackMode.Values,
                     DataLabels = true,

                }
            };
        }
        //chart 1
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        //chart 1
        public SeriesCollection SeriesCollection2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        private void BindGrid()
        {
            if (begin < ends && ends <= DateTime.Now)
            {
                string s1 = $"select Product.Name as NameProduct,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as Sums from Product left join Trans on Product.ID=Trans.IDGame Where Trans.Dated >= #{begin.ToString()}# and Trans.Dated <= #{ends.ToString()}# group by Product.Name";
                string s2 = $"select NameProduct,(total - sub) as Sums" +
                    $" From (select Product.Name as NameProduct,Product.Amount as total,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sub from Product left join Trans on Product.ID=Trans.IDGame where Trans.Dated >= #{begin.ToString()}# and Trans.Dated <= #{ends.ToString()}# group by Product.Name,Product.Amount) as tableA";
                dp.withQuery(s1);
                dp1.withQuery(s2);

                string s3 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Total), 0, Trans.Total)) as sTotal from Product left join Trans on Product.ID=Trans.IDGame Where Trans.Dated >= #{begin.ToString()}# and Trans.Dated <= #{ends.ToString()}# group by Product.Name";

                dp2.withQuery(s3);
            }
            else
            {
                string c = "select Product.Name as NameProduct,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as Sums from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name";
                dp.withQuery(c);
                dp1.withQuery("select NameProduct,(total - sub) as Sums" +
                    " From (select Product.Name as NameProduct,Product.Amount as total,Sum(IIF(IsNull(Trans.Amount), 0, Trans.Amount)) as sub from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name,Product.Amount) as tableA");

                string s1 = $"select Product.Name as Name, Sum(IIF(IsNull(Trans.Total), 0, Trans.Total)) as sTotal from Product left join Trans on Product.ID=Trans.IDGame group by Product.Name";

                dp2.withQuery(s1);
            }
           
        }
    }
}
