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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : UserControl
    {
        public ReportWindow()
        {
            InitializeComponent();

            dpFromDate.SelectedDate = dpToDate.SelectedDate = DateTime.Now;

            DataContext = new DrawColummChart(dpFromDate, dpToDate);
        }


        private void BtnLineChart_Click(object sender, RoutedEventArgs e)
        {

            DataContext = new DrawLineChart();
        }

        private void BtnColumnChart_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DrawColummChart(dpFromDate, dpToDate);
           
        }
        private void BtnPieChart_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DrawPieChart(dpFromDate, dpToDate);
           
        }
    }
}
