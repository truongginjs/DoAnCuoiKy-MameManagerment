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
using System.Data;
using System.Text.RegularExpressions;
using Design.Context;

namespace Design
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : UserControl
    {
        AddScreen a = null;
        DataProvider dp1;
        DataProvider dp;
        DataProvider dp2;
        public CategoryWindow()
        {
            InitializeComponent();
            dp1 = new DataProvider();
            DataProvider dp = new DataProvider();
            DataProvider dp2 = new DataProvider();
            BindGird();


            //txtID.Text = (Common.Instance.categories.Count()+1).ToString();
        }

        public void BindGird()
        {

            //tableDataGrid.ItemsSource = Common.Instance.categories.Where(c => c.Deleted == false);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (tableDataGrid.SelectedItems.Count > 0)
            //{
            //    MessageBoxResult result = MessageBox.Show("Bạn có chắc là muốn xóa?",
            //                              "Confirmation",
            //                              MessageBoxButton.YesNo,
            //                              MessageBoxImage.Question);

            //    if (result == MessageBoxResult.Yes)
            //    {
            //        DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];

            //        dp.deleteRow("Category", row["ID"].ToString());
            //        BindGird();
            //    }

            //    // the following can be handled as if/else statements as well
            //    clearAll();
            //}
            //else
            //{
            //    MessageBox.Show("Hay chọn một đối tượng cần xóa");
            //}
        }

        void clearAll()
        {
            //txtID.Text = dp2.CreateID("Category").ToString();
            //txtName.Clear();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (String.IsNullOrEmpty(txtSearch.Text))
            //{
            //    BindGird();
            //    return;
            //}

            //tableDataGrid.ItemsSource = dp.Search("Category", txtSearch.Text).AsDataView();
        }

        private void TableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (tableDataGrid.SelectedItems.Count > 0)
            //{
            //    DataRowView row = (DataRowView)tableDataGrid.SelectedItems[0];
            //    txtID.Text = row["ID"].ToString();
            //    txtName.Text = row["Name"].ToString();
            //    btnAdd.Content = "Update";
            //    btnClear.IsEnabled = true;
            //}
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //clearAll();
            //btnAdd.Content = "Add";
            //MessageBox.Show("" + txtName.Text.Length);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //if (btnAdd.Content.ToString() == "Add")
            //{
            //    string value = $"{txtID.Text},'{txtName.Text}', false";

            //    dp1.Add("Category", value);
            //    clearAll();
            //    BindGird();
            //}
            //else
            //{
            //    string value = $"Name='{txtName.Text}'";

            //    dp1.Update("Category", value, txtID.Text);
            //    BindGird();
            //}
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if (a == null)
            {
                //Instantiate the object and call the Open() method 
                a = new AddScreen("Category");
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
            //tableDataGrid.ItemsSource = dp2.showAll("Trans", "1=1").AsDataView();
            clearAll();
        }
        void AddScreen_Closed(object sender, EventArgs e)
        {
            a = null;
        }
    }
}

