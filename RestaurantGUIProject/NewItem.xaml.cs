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

namespace RestaurantGUIProject
{
    /// <summary>
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : Window
    {
        public NewItem()
        {
            InitializeComponent();

            txtReadOnlyID.Text = MainWindow.systemManger.allItems.Count().ToString();
            cmbItemType.ItemsSource = MainWindow.systemManger.mealTypes;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtReadOnlyID.Text != "" && txtName.Text != "" && txtCost.Text != "" && cmbItemType.SelectedValue != null && decimal.TryParse(txtCost.Text, out decimal result))
            {
                MainWindow.systemManger.allItems.Add(new Item(Convert.ToInt32(txtReadOnlyID.Text), txtName.Text, Convert.ToDecimal(txtCost.Text), cmbItemType.SelectedValue.ToString()));
                this.Close();
            }
            else
            {
                MessageBox.Show("Some fields are missing, or an incorrect format. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
