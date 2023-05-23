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
    /// Interaction logic for NewRestaurant.xaml
    /// </summary>
    public partial class NewRestaurant : Window
    {
        internal List<int> hours = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        internal List<int> minutes = new List<int>() { 0, 15, 30, 45 };
        public NewRestaurant()
        {
            InitializeComponent();


            cmbHotDrink.ItemsSource = grabHotDrinks();
            cmbHotDrink.DisplayMemberPath = "name";

            cmbBreakfast.ItemsSource = grabBreakfasts();
            cmbBreakfast.DisplayMemberPath = "name";

            cmbLunch.ItemsSource = grabLunches();
            cmbLunch.DisplayMemberPath = "name";

            cmbDinner.ItemsSource = grabDinners();
            cmbDinner.DisplayMemberPath = "name";

            cmbAlcohol.ItemsSource = grabAlcoholicDrinks();
            cmbAlcohol.DisplayMemberPath = "name";

            txtReadonlyID.Text = Convert.ToInt32(MainWindow.systemManger.allRestaurants.Count() + 1).ToString();

            cmbOpeningTimeHours.ItemsSource = hours;
            cmbClosingTimeHours.ItemsSource = hours;
            cmbBreakfastStartHours.ItemsSource = hours;
            cmbBreakfastStopHours.ItemsSource = hours;
            cmbLunchStartHours.ItemsSource = hours;
            cmbLunchStopHours.ItemsSource = hours;
            cmbDinnerStartHours.ItemsSource = hours;
            cmbDinnerStopHours.ItemsSource = hours;
            cmbAlcoholStartHours.ItemsSource = hours;
            cmbAlcoholStopHours.ItemsSource = hours;

            cmbOpeningTimeMins.ItemsSource = minutes;
            cmbClosingTimeMins.ItemsSource = minutes;
            cmbBreakfastStartMins.ItemsSource = minutes;
            cmbBreakfastStopMins.ItemsSource = minutes;
            cmbLunchStartMins.ItemsSource = minutes;
            cmbLunchStopMins.ItemsSource = minutes;
            cmbDinnerStartMins.ItemsSource = minutes;
            cmbDinnerStopMins.ItemsSource = minutes;
            cmbAlcoholStartMins.ItemsSource = minutes;
            cmbAlcoholStopMins.ItemsSource = minutes;
        }

        internal List<Menu> grabHotDrinks()
        {
            List<Menu> hotDrinks = new List<Menu>();

            foreach (Menu menu in MainWindow.systemManger.allMenus)
            {
                if (menu.mealType == "Hot Drink")
                {
                    hotDrinks.Add(menu);
                }
            }
            return hotDrinks;
        }
        internal List<Menu> grabBreakfasts()
        {
            List<Menu> breakfasts = new List<Menu>();

            foreach (Menu menu in MainWindow.systemManger.allMenus)
            {
                if (menu.mealType == "Breakfast")
                {
                    breakfasts.Add(menu);
                }
            }
            return breakfasts;
        }
        internal List<Menu> grabLunches()
        {
            List<Menu> lunches = new List<Menu>();

            foreach (Menu menu in MainWindow.systemManger.allMenus)
            {
                if (menu.mealType == "Lunch")
                {
                    lunches.Add(menu);
                }
            }
            return lunches;
        }
        internal List<Menu> grabDinners()
        {
            List<Menu> dinners = new List<Menu>();

            foreach (Menu menu in MainWindow.systemManger.allMenus)
            {
                if (menu.mealType == "Dinner")
                {
                    dinners.Add(menu);
                }
            }
            return dinners;
        }
        internal List<Menu> grabAlcoholicDrinks()
        {
            List<Menu> alcoholicDrinks = new List<Menu>();

            foreach (Menu menu in MainWindow.systemManger.allMenus)
            {
                if (menu.mealType == "Alcoholic Drink")
                {
                    alcoholicDrinks.Add(menu);
                }
            }
            return alcoholicDrinks;
        }




        private void cmbHotDrink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu getMenu = cmbHotDrink.SelectedItem as Menu;
            lstHotDrinks.ItemsSource = getMenu?.items;
        }

        private void cmbBreakfast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu getMenu = cmbBreakfast.SelectedItem as Menu;
            lstBreakfast.ItemsSource = getMenu?.items;
        }

        private void cmbLunch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu getMenu = cmbLunch.SelectedItem as Menu;
            lstLunch.ItemsSource = getMenu?.items;
        }

        private void cmbDinner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu getMenu = cmbDinner.SelectedItem as Menu;
            lstDinner.ItemsSource = getMenu?.items;
        }

        private void cmbAlcohol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu getMenu = cmbAlcohol.SelectedItem as Menu;
            lstAlcohol.ItemsSource = getMenu?.items;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (checkIfPopulated())
            {
                TimeOnly openingTime = new TimeOnly(Convert.ToInt32(cmbOpeningTimeHours.Text), Convert.ToInt32(cmbOpeningTimeMins.Text));
                TimeOnly closingTime = new TimeOnly(Convert.ToInt32(cmbClosingTimeHours.Text), Convert.ToInt32(cmbClosingTimeMins.Text));
                TimeOnly breakfastStart = new TimeOnly(Convert.ToInt32(cmbBreakfastStartHours.Text), Convert.ToInt32(cmbBreakfastStartMins.Text));
                TimeOnly breakfastStop = new TimeOnly(Convert.ToInt32(cmbBreakfastStopHours.Text), Convert.ToInt32(cmbBreakfastStopMins.Text));
                TimeOnly lunchStart = new TimeOnly(Convert.ToInt32(cmbLunchStartHours.Text), Convert.ToInt32(cmbLunchStartMins.Text));
                TimeOnly lunchStop = new TimeOnly(Convert.ToInt32(cmbLunchStopHours.Text), Convert.ToInt32(cmbLunchStopMins.Text));
                TimeOnly dinnerStart = new TimeOnly(Convert.ToInt32(cmbDinnerStartHours.Text), Convert.ToInt32(cmbDinnerStartMins.Text));
                TimeOnly dinnerStop = new TimeOnly(Convert.ToInt32(cmbDinnerStopHours.Text), Convert.ToInt32(cmbDinnerStopMins.Text));
                TimeOnly alcoholStart = new TimeOnly(Convert.ToInt32(cmbAlcoholStartHours.Text), Convert.ToInt32(cmbAlcoholStartMins.Text));
                TimeOnly alcoholStop = new TimeOnly(Convert.ToInt32(cmbAlcoholStopHours.Text), Convert.ToInt32(cmbDinnerStopMins.Text));

                MainWindow.systemManger.allRestaurants.Add(new Restaurant(Convert.ToInt32(txtReadonlyID.Text), txtUpdateName.Text, openingTime, closingTime, breakfastStart, breakfastStop, lunchStart, lunchStop, dinnerStart, dinnerStop, alcoholStart, alcoholStop, cmbBreakfast.SelectedValue as Menu, cmbLunch.SelectedValue as Menu, cmbDinner.SelectedValue as Menu, cmbAlcohol.SelectedValue as Menu, cmbHotDrink.SelectedValue as Menu));
                MessageBox.Show("Saved " + txtUpdateName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Fields are empty, please fill all options before trying to save.");
            }
        }


        internal bool checkIfPopulated()
        {
            if (txtReadonlyID.Text != "" && txtUpdateName.Text != "" && cmbOpeningTimeHours.SelectedValue != null && cmbOpeningTimeMins.SelectedValue != null && cmbClosingTimeHours.SelectedValue != null && cmbClosingTimeMins.SelectedValue != null && cmbBreakfastStartHours.SelectedValue != null && cmbBreakfastStartMins.SelectedValue != null && cmbBreakfastStopHours.SelectedValue != null && cmbBreakfastStopMins.SelectedValue != null && cmbLunchStartHours.SelectedValue != null && cmbLunchStartMins.SelectedValue != null && cmbLunchStopHours.SelectedValue != null && cmbLunchStopMins.SelectedValue != null && cmbDinnerStartHours.SelectedValue != null && cmbDinnerStartMins.SelectedValue != null && cmbDinnerStopHours.SelectedValue != null && cmbDinnerStopMins.SelectedValue != null && cmbAlcoholStartHours.SelectedValue != null && cmbAlcoholStartMins.SelectedValue != null && cmbAlcoholStopHours.SelectedValue != null && cmbAlcoholStopMins.SelectedValue != null && cmbBreakfast.SelectedValue != null && cmbLunch.SelectedValue != null && cmbDinner.SelectedValue != null && cmbHotDrink.SelectedValue != null && cmbAlcohol.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
