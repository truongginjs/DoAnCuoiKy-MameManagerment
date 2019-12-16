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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xls;*xlsx)|*.xls;*xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                Chip.Content = openFileDialog.FileName;
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
            var dt1 = dp.showAll(table,null);
            //MessageBox.Show(dt.Rows.Count+"");
             string queryAdd="";

            foreach (DataRow i in dt.Rows)
            {
                bool kt = true;
                foreach (DataRow j in dt1.Rows)
                {
                    if (i["ID"].ToString() == j["ID"].ToString())
                    {
                        //string s = $"({i["ID"].ToString()},{i["Name"].ToString()},{i["Amount"].ToString()},{i["Publisher"].ToString()},{i["Category"].ToString()},{i["PurchaseCost"].ToString()},{i["SaleCost"].ToString()},{i["Dated"].ToString()},{i["Deleted"].ToString()})";
                        kt = false;
                        break;
                    }
                }
                if(kt)
                {
                    switch (table)
                    {
                        case "Product":
                            queryAdd = $"{i["ID"].ToString()}, '{i["Name"].ToString()}', {i["Amount"].ToString()}, '{i["Publisher"].ToString()}', '{i["Category"].ToString()}', '{i["PurchaseCost"].ToString()}', {i["SaleCost"].ToString()}, '{i["Dated"].ToString()}', {i["Deleted"].ToString()}";
                            break;
                        case "Category":
                            queryAdd = $"{ i["ID"].ToString()}, '{ i["Name"].ToString()}',{ i["Deleted"].ToString()}";
                            break;
                        case "Trans":
                            queryAdd = $"{i["ID"].ToString()}, {i["IDGame"].ToString()},{i["Amount"].ToString()}, '{i["PlacePayment"].ToString()}', '{i["ModePayment"].ToString()}', '{i["Deposit"].ToString()}', {i["Total"].ToString()}, '{i["Dated"].ToString()}', {i["Received"].ToString()}";
                            break;
                        default:
                            break;
                    }
                    dp1.Add(table, queryAdd);
                }
            }
            /*// First query, this creates the target SelectedFeeds but fail if it exists
            string createText = @"SELECT FeedLibrary.* INTO [SelectedFeeds] 
                       FROM FeedLibrary
                       where ID=@id";
            // Second query, it appends to SelectedFeeds but it should exists
            string appendText = @"INSERT INTO SelectedFeeds
                       SELECT * FROM FeedLibrary
                       WHERE FeedLibrary.ID=@id";

            using (OleDbConnection Connection = new OleDbConnection(StrCon))
            using (OleDbCommand cmd = new OleDbCommand("", Connection))
            {
                Connection.Open();

                // Get info about the SelectedFeeds table....
                var schema = Connection.GetSchema("Tables", new string[] { null, null, "SelectedFeeds", null });

                // Choose which command to execute....
                cmd.CommandText = schema.Rows.Count > 0 ? appendText : createText;

                // Parameter @id is the same for both queries
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = Convert.ToInt32(frm2.FeedSelectListBox.SelectedValue);

                cmd.ExecuteNonQuery();
            }*/
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
