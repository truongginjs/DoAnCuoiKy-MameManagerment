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
namespace Design
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : UserControl
    {
        AddScreen a = null;
        DataProvider dp = new DataProvider();
        DataProvider dP1 = new DataProvider();
        DataProvider dP2 = new DataProvider();

        public ProductWindow()
        {
            InitializeComponent();
            BindGird();
            
        }

        public void BindGird()
        {
            tableDataGrid.ItemsSource = dp.showField("Product","ID, Name, Amount, Publisher, Category, PurchaseCost,SaleCost,Dated","Deleted=false").AsDataView();
            cbbCategory.ItemsSource = dP1.showAll("Category", "Deleted=false").AsDataView();

            cbbCategory.DisplayMemberPath = "Name";
            cbbCategory.SelectedValuePath = "ID";

            txtID.Text = dP2.CreateID("Product").ToString();
        }
       
       

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                BindGird();
                return;
            }

            tableDataGrid.ItemsSource = dp.Search("Product", txtSearch.Text).AsDataView();
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tableDataGrid.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc là muốn xóa?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];

                    dp.deleteRow("Product", row["ID"].ToString());
                    BindGird();
                }

                // the following can be handled as if/else statements as well
                clearAll();
            }
            else
            {
                MessageBox.Show("Hay chọn một đối tượng cần xóa");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (btnAdd.Content.ToString() == "Add")
            {
                string value = $"{txtID.Text},'{txtName.Text}', {txtAmount.Text},'{txtPublisher.Text}', '{cbbCategory.Text}', {txtPurchase.Text}, '{txtSale.Text}', {txtDate.Text}, false";

                dP1.Add("Product", value);
                clearAll();
                BindGird();
            }
            else
            {
                string value = $"Name='{txtName.Text}', Amount={txtAmount.Text},Publisher='{txtPublisher.Text}', Category='{cbbCategory.Text}', PurchaseCost={txtPurchase.Text}, SaleCost={txtSale.Text}, Dated='{txtDate.Text}'";

                dP1.Update("Product", value, "ID = "+txtID.Text.ToString());
                clearAll();

                BindGird();
            }
                
        }

        void clearAll()
        {
            txtID.Text = dP2.CreateID("Product").ToString();
            txtName.Clear();
            txtAmount.Clear();
            txtPublisher.Clear();
            cbbCategory.SelectedItem = null;
            txtPurchase.Clear();
            txtSale.Clear();
            txtDate.SelectedDate = null;      
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
            btnAdd.Content = "Add";
           // MessageBox.Show("" + txtName.Text.Length + txtAmount.Text.Length + txtPublisher.Text.Length + cbbCategory.Text.Length + txtSale.Text.Length + txtDate.Text.Length);
        }

        private void TableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];
            txtID.Text = row["ID"].ToString();
            txtName.Text = row["Name"].ToString();
            txtAmount.Text = row["Amount"].ToString();
            txtPublisher.Text = row["Publisher"].ToString();
            cbbCategory.Text = row["Category"].ToString();
            txtPurchase.Text = row["PurchaseCost"].ToString();
            txtSale.Text = row["SaleCost"].ToString();
            txtDate.SelectedDate = DateTime.Parse(row["Dated"].ToString());
            btnAdd.Content = "Update";
            btnClear.IsEnabled = true;
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
    }
}

