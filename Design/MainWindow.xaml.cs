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

namespace Design
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UserControl Pruduct = new ProductWindow();
        private UserControl Category = null;
        private UserControl Trans = null;
        private UserControl Report = null;
        
        public MainWindow()
        {
            InitializeComponent();
            //string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show(path);
            DataContext = Pruduct;
            btnProduct.IsEnabled = false;
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            DataContext = Pruduct;
            btnProduct.IsEnabled = false;
            btnCategory.IsEnabled = true;
            btnTransaction.IsEnabled = true;
            btnStatis.IsEnabled = true;
        }
        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            if (Category == null)
            {
                Category = new CategoryWindow();
            }
            DataContext = Category;
            btnProduct.IsEnabled = true;
            btnCategory.IsEnabled = false;
            btnTransaction.IsEnabled = true;
            btnStatis.IsEnabled = true;
        }

        private void BtnTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (Trans == null)
            {
                Trans = new TransactionWindow();
            }
            DataContext = Trans;
            btnProduct.IsEnabled = true;
            btnCategory.IsEnabled = true;
            btnTransaction.IsEnabled = false;
            btnStatis.IsEnabled = true;
        }

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {
            if (Report == null)
            {
                Report = new ReportWindow();
            }
            DataContext = Report;
            btnProduct.IsEnabled = true;
            btnCategory.IsEnabled = true;
            btnTransaction.IsEnabled = true;
            btnStatis.IsEnabled = false;
        }

        private void BtnNewChart_Click(object sender, RoutedEventArgs e)
        {
            
            btnProduct.IsEnabled = true;
            btnCategory.IsEnabled = true;
            btnTransaction.IsEnabled = true;
            btnStatis.IsEnabled = false;
        }


        /*BindGrid();
BindComboBox();
}

//Display records in grid
private void BindComboBox()
{
DataProvider a = new DataProvider();
OleDbCommand cmd = new OleDbCommand();
if (con.State != ConnectionState.Open)
con.Open();
cmd.Connection = con;
cmd.CommandText = a.QuerySQL("Category");
//cmd.Parameters.AddWithValue("@mn", table);
OleDbDataAdapter da = new OleDbDataAdapter(cmd);
dt = new DataTable();
da.Fill(dt);
//var pd = new List<Product>();
cbBoxCol.ItemsSource = dt.AsDataView();
cbBoxCol.DisplayMemberPath = "Name";
cbBoxCol.SelectedValuePath = "ID";

}
private void BindGrid()
{
DataProvider a = new DataProvider();
OleDbCommand cmd = new OleDbCommand();
if (con.State != ConnectionState.Open)
con.Open();
cmd.Connection = con;
cmd.CommandText = a.QuerySQL("Product");
//cmd.Parameters.AddWithValue("@mn", table);
OleDbDataAdapter da = new OleDbDataAdapter(cmd);
dt = new DataTable();
da.Fill(dt);
//var pd = new List<Product>();
tableDataGrid.ItemsSource = dt.AsDataView();
}

private void Search(String s)
{
OleDbCommand cmd = new OleDbCommand();
if (con.State != ConnectionState.Open)
con.Open();
cmd.Connection = con;
cmd.CommandText = "select * from Product where Name like '%"+ s + "%'";
//cmd.Parameters.AddWithValue("@ma", "Product");
//cmd.Parameters.AddWithValue("@mb", s);

OleDbDataAdapter da = new OleDbDataAdapter(cmd);
dt = new DataTable();
da.Fill(dt);
tableDataGrid.ItemsSource = dt.AsDataView();

}
private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
{
var view = CollectionViewSource.GetDefaultView(tableDataGrid.ItemsSource);

if (String.IsNullOrEmpty(txtSearch.Text))
{
BindGrid();
return;
}

Search(txtSearch.Text);
}


private void BtnDelete_Click(object sender, RoutedEventArgs e)
{
if (tableDataGrid.SelectedItems.Count > 0)
{
DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];

OleDbCommand cmd = new OleDbCommand();
if (con.State != ConnectionState.Open)
con.Open();
cmd.Connection = con;
cmd.CommandText = "delete from Product where ID=" + row["ID"].ToString();
cmd.ExecuteNonQuery();
BindGrid();
MessageBox.Show("Xóa thành công");
}
else
{
MessageBox.Show("Hay chọn một đối tượng cần xóa");
}
}

private void BtnAdd_Click(object sender, RoutedEventArgs e)
{
AddScreen a = new AddScreen();
a.Show();
}



private void BtnProduct_Click(object sender, RoutedEventArgs e)
{

}

private void BtnCategory_Click(object sender, RoutedEventArgs e)
{

}

private void BtnTransaction_Click(object sender, RoutedEventArgs e)
{
DataContext = new TransactionWindow();
}*/
        //class Product
        //{
        //    public int ID { get; set; }
        //    public String name { get; set; }
        //    public int amount { get; set; }
        //    public String publisher { get; set; }
        //    public String category { get; set; }
        //    public int purchaseCost { get; set; }
        //    public int sale { get; set; }
        //    public float discount { get; set; }
        //}
    }
}
