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
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using Microsoft.Win32;
using System.Data.Entity.Core;
using Design.Context;
using Design.Model;

namespace Design
{
    /// <summary>
    /// Interaction logic for AddScreen.xaml
    /// </summary>
    public partial class AddScreen : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler DataChanged;

        DataProvider dp = new DataProvider();
        DataProvider dp1 = new DataProvider();
        DataTable dt;
        private string table;
        public AddScreen(string s)
        {
            InitializeComponent();
            table = s;
        }

        public AddScreen()
        {
            
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            Human temp = Common.Instance.humen.ToList().Where(p => p.name == "A").First();
            txtTest.Content = temp.name+temp.dateOfBirth.ToString();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel files (*.xls;*xlsx)|*.xls;*xlsx|All files (*.*)|*.*";
            //if (openFileDialog.ShowDialog() == true)
            //    Chip.Content = openFileDialog.FileName;
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {


            string Conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Chip.Content + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = Conn;
            string sql = $"select * from [{txtSheet.Text}$]";
            var da = new OleDbDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            tableDataGrid.ItemsSource = dt.AsDataView();
            con.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataChangedEventHandler handler = DataChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            this.Close();
        }

    }
}
