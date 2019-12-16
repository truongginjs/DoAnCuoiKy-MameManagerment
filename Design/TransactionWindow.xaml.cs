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
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : UserControl
    {
        AddScreen a = null;
        DataProvider dp = new DataProvider();

        DataProvider dp1 = new DataProvider();
        DataProvider dp2 = new DataProvider();
        DataProvider dp3 = new DataProvider();
        DataProvider dp4 = new DataProvider();

        public TransactionWindow()
        {
            InitializeComponent();

            cbbNameGame.ItemsSource = cbbIdG.ItemsSource = dp.showAll("Product","Deleted=false").AsDataView();
            cbbNameGame.DisplayMemberPath = "Name";
            cbbNameGame.SelectedValuePath = "Name";

            //cbbIdG.ItemsSource = dp2.showAll("Product", "1=1").AsDataView();
            cbbIdG.DisplayMemberPath = "ID";
            cbbIdG.SelectedValuePath = "ID";

            tableDataGrid.ItemsSource = dp3.showAll("Trans",null).AsDataView();
            //"ID, IDGame, Amount, PlacePayment,ModePayment,ModePayment, "
            txtId.Text = dp1.CreateID("Trans").ToString();
        }

        private void CbbPlance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbPlance.SelectedIndex == 1) 
            {
                txtDeposit.IsEnabled = true;
            }
            else
            {
                txtDeposit.IsEnabled = false;
                txtDeposit.Clear();
            }
        }

        private void TxtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void TxtDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        

        private void CbbIdG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbIdG.SelectedIndex > -1&&txtAmount.Text.Length > 0)
            {
                string condition = "ID = " + cbbIdG.SelectedValue;
                int t = int.Parse(dp2.Get("Product", "SaleCost", condition));
                txtSubT.Text = (t * int.Parse(txtAmount.Text)).ToString();
            }
        }

        private void TxtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbbIdG.SelectedIndex > -1 && txtAmount.Text.Length > 0)
            {
                string condition = "ID = " + cbbIdG.SelectedValue;
                int t = int.Parse(dp2.Get("Product", "SaleCost", condition));
                txtSubT.Text = (t * int.Parse(txtAmount.Text)).ToString();
            }
        }

        private void cbbSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSubT.Text.Length > 0 && cbbSales.SelectedIndex > -1)
            {
                switch (cbbSales.SelectedIndex)
                {
                    case 0:
                        //none
                        txtSales.Text = "0";
                        break;
                    case 1:
                        //blackFriday
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.2).ToString();
                        break;
                    case 2:
                        //cyperMonday
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.15).ToString();
                        break;
                    case 3:
                        //Coupon
                        txtSales.Text = (int.Parse((txtSubT.Text)) - 20000).ToString();
                        break;
                    case 4:
                        //voicher
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.2).ToString();

                        break;
                }
            }


        }
        private void TxtSubT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSubT.Text.Length > 0 && cbbSales.SelectedIndex > -1)
            {
                switch (cbbSales.SelectedIndex)
                {
                    case 0:
                        //none
                        txtSales.Text = "0";
                        break;
                    case 1:
                        //blackFriday
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.8).ToString();
                        break;
                    case 2:
                        //cyperMonday
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.85).ToString();
                        break;
                    case 3:
                        //Coupon
                        txtSales.Text = (int.Parse((txtSubT.Text)) - 20000).ToString();
                        break;
                    case 4:
                        //voicher
                        txtSales.Text = (int.Parse((txtSubT.Text)) * 0.8).ToString();

                        break;
                }
            }
            if (txtSubT.Text.Length > 0 && txtSales.Text.Length > 0)
            {
                txtTotal.Text = (int.Parse(txtSubT.Text) - int.Parse(txtSales.Text)).ToString();
            }
        }

        private void TxtSales_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSubT.Text.Length > 0 && txtSales.Text.Length > 0)
            {
                txtTotal.Text = (int.Parse(txtSubT.Text) - int.Parse(txtSales.Text)).ToString();
            }
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

            if (a == null)
            {
                //Instantiate the object and call the Open() method 
                a = new AddScreen("Trans");
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
            tableDataGrid.ItemsSource = dp3.showAll("Trans", "1=1").AsDataView();

        }
        void AddScreen_Closed(object sender, EventArgs e)
        {
            a = null;
        }
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            string temp="";
            if(string.IsNullOrEmpty(txtDeposit.Text))
            {
                temp = "0";
            }
            else
            {
                temp = txtDeposit.Text;
            }
            string value = $"{txtId.Text}, {cbbIdG.Text},{txtAmount.Text}, '{cbbPlance.Text}', '{cbbMode.Text}', {temp}, {txtTotal.Text}, '{DateTime.Now.Date.ToString("dd/MM/yyyy")}', true";
            dp4.Add("Trans",value);
            tableDataGrid.ItemsSource = dp3.showAll("Trans", "1=1").AsDataView();
            ClearAll();

        }
        private void ClearAll()
        {
            txtId.Text = dp1.CreateID("Trans").ToString();
            cbbIdG.SelectedItem = null;
            cbbMode.SelectedItem = null;
            cbbNameGame.SelectedItem = null;
            cbbPlance.SelectedItem = null;
            txtAmount.Text = "1";
            txtDeposit.Text = "";
            txtSales.Text = "";
            cbbSales.SelectedItem = null;
            txtSubT.Text = "";
            txtTotal.Text = null;

        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
    }
}
