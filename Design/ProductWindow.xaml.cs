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
using Design.Context;
using Design.Model;
using System.Data.Entity.Migrations;

namespace Design
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : UserControl
    {
        AddScreen a = null;
        DataGrid tableDataGrid = new DataGrid();
        public ProductWindow()
        {
            InitializeComponent();
            BindGird();
            
        }

        public void BindGird()
        {
            var db = Common.Instance;
            tableDataGrid.ItemsSource = db.games.Where(g=>g.Deleted==false).ToList();
            //cbbCategory.ItemsSource = db.categories.Where(g => g.Deleted == false).ToList();

            //cbbCategory.DisplayMemberPath = "name";

            //txtID.Text = (db.games.Count()+1).ToString();
        }
       
       

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var db = Common.Instance;
            //if (String.IsNullOrEmpty(txtSearch.Text))
            //{
            //    BindGird();
            //    return;
            //}
            //var keywords = txtSearch.Text.Split( new char[] { ' ', '/', ',', '.' },StringSplitOptions.RemoveEmptyEntries);
            //tableDataGrid.ItemsSource = db.games.Where(g => keywords.Any(k => g.Name.Contains(k)));
        }




        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ShopGameContext context = Common.Instance;
            //if (btnAdd.Content.ToString() == "Add")
            //{
            //    //string value = $"{txtID.Text},'{txtName.Text}', {txtAmount.Text},'{txtPublisher.Text}', '{cbbCategory.Text}', {txtPurchase.Text}, '{txtSale.Text}', {txtDate.Text}, false";
            //    var game = new Game { name = txtName.Text, publisher = txtPublisher.Text, category = cbbCategory.SelectedValue as Category, purchaseCost = long.Parse(txtPurchase.Text), SaleCost = long.Parse(txtSale.Text), };
            //    context.games.Add(game);
            //    context.SaveChanges();
            //    clearAll();
            //    BindGird();
            //}
            //else
            //{
            //    var game = new Game { name = txtName.Text, publisher = txtPublisher.Text, category = cbbCategory.SelectedValue as Category, purchaseCost = long.Parse(txtPurchase.Text), SaleCost = long.Parse(txtSale.Text), };
            //    context.games.AddOrUpdate(game);
            //    clearAll();

            //    BindGird();
            //}
                
        }

        void clearAll()
        {
            //txtName.Clear();
            //txtAmount.Clear();
            //txtPublisher.Clear();
            //cbbCategory.SelectedItem = null;
            //txtPurchase.Clear();
            //txtSale.Clear();
            //txtDate.SelectedDate = null;      
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
            //btnAdd.Content = "Add";
           // MessageBox.Show("" + txtName.Text.Length + txtAmount.Text.Length + txtPublisher.Text.Length + cbbCategory.Text.Length + txtSale.Text.Length + txtDate.Text.Length);
        }

        private void TableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];
            //txtID.Text = row["ID"].ToString();
            //txtName.Text = row["Name"].ToString();
            //txtAmount.Text = row["Amount"].ToString();
            //txtPublisher.Text = row["Publisher"].ToString();
            //cbbCategory.Text = row["Category"].ToString();
            //txtPurchase.Text = row["PurchaseCost"].ToString();
            //txtSale.Text = row["SaleCost"].ToString();
            //txtDate.SelectedDate = DateTime.Parse(row["Dated"].ToString());
            //btnAdd.Content = "Update";
            //btnClear.IsEnabled = true;
        }

        private void TxtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void TxtPurchase_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void TxtSale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if (a == null)
            {
                //Instantiate the object and call the Open() method 
                a = new AddScreen("Product");
                a.Show();
                //Add a event handler to set null our window object when it will be closed
                a.Closed += new EventHandler(AddScreen_Closed);
            }
            //If the window was created and your window isn't active
            //we call the method Activate to call the specific window to front
            else if (a != null && !a.IsActive)
            {
                a.Activate();
            }
            a.DataChanged += AddScreen_DataChanged;
            a.Show();

        }

        private void AddScreen_DataChanged(object sender, EventArgs e)
        {
            BindGird();
            clearAll();
        }
        void AddScreen_Closed(object sender, EventArgs e)
        {
            a = null;
        }

        private void TxtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // MessageBox.Show(txtDate.SelectedDate.Value.ToString("MM/dd/yyyy"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

