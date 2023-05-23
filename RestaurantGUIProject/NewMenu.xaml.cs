using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewMenu.xaml
    /// </summary>
    public partial class NewMenu : Window
    {
        ObservableCollection<Item> selectedItems = new ObservableCollection<Item>();
        public NewMenu()
        {
            InitializeComponent();

            cmbMealTypes.ItemsSource = MainWindow.systemManger.mealTypes;
            txtReadOnlyID.Text = MainWindow.systemManger.allMenus.Count().ToString();
        }

        private void cmbMealTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Item> additions = new List<Item>();
            foreach (Item item in MainWindow.systemManger.allItems)
            {
                if (item.itemType == cmbMealTypes.SelectedValue.ToString())
                {
                    additions.Add(item);
                }
            }
            selectedItems.Clear();
            lstAllItemsOfType.ItemsSource = additions;

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItems.Contains(lstAllItemsOfType.SelectedItem as Item) == false)
            {
                selectedItems.Add(lstAllItemsOfType.SelectedValue as Item);
                lstSelectedItems.ItemsSource = selectedItems;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && cmbMealTypes.SelectedValue != null && selectedItems.Count != 0)
            {
                MainWindow.systemManger.allMenus.Add(new Menu(Convert.ToInt32(txtReadOnlyID.Text), txtName.Text, cmbMealTypes.SelectedValue.ToString(), selectedItems.ToList<Item>()));
                MessageBox.Show(txtName.Text + " has been added to menus.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Fields are missing, the menu cannot be saved.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
