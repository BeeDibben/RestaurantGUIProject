using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace RestaurantGUIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime realtime;

        public static SystemManager systemManger = new SystemManager();

        public MainWindow()
        {


            timer.Tick += new EventHandler(onTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();


            InitializeComponent();



            cmbRestaurantName.ItemsSource = systemManger.allRestaurants;
            cmbRestaurantName.DisplayMemberPath = "name";


        }

        internal void MainWindowClosing(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private List<Item> grabItems()
        {
            List<Item> items = new List<Item>();

            Restaurant getRestaurant = cmbRestaurantName.SelectedItem as Restaurant;

            if (getRestaurant != null)
            {
                foreach (Menu menu in grabMenus())
                {
                    foreach (Item item in menu.items)
                    {
                        items.Add(item);
                    }
                }

            }

            return items;
        }

        private List<Menu> grabMenus()
        {
            List<Menu> menus = new List<Menu>();

            Restaurant getRestaurant = cmbRestaurantName.SelectedItem as Restaurant;




            menus.Add(getRestaurant.hotDrink);
            if (TimeOnly.FromDateTime(realtime) >= getRestaurant.breakfastStart & TimeOnly.FromDateTime(realtime) >= getRestaurant.breakfastStart & TimeOnly.FromDateTime(realtime) <= getRestaurant.breakfastStop & TimeOnly.FromDateTime(realtime) <= getRestaurant.breakfastStop)
            {
                menus.Add(getRestaurant.breakfast);
            }

            if (TimeOnly.FromDateTime(realtime) >= getRestaurant.lunchStart & TimeOnly.FromDateTime(realtime) >= getRestaurant.lunchStart & TimeOnly.FromDateTime(realtime) <= getRestaurant.lunchStop & TimeOnly.FromDateTime(realtime) <= getRestaurant.lunchStop)
            {
                menus.Add(getRestaurant.lunch);
            }

            if (TimeOnly.FromDateTime(realtime) >= getRestaurant.dinnerStart & TimeOnly.FromDateTime(realtime) >= getRestaurant.dinnerStart & TimeOnly.FromDateTime(realtime) <= getRestaurant.dinnerStop & TimeOnly.FromDateTime(realtime) <= getRestaurant.dinnerStop)
            {
                menus.Add(getRestaurant.dinner);
            }

            if (TimeOnly.FromDateTime(realtime) >= getRestaurant.alcoholStart & TimeOnly.FromDateTime(realtime) >= getRestaurant.alcoholStart & TimeOnly.FromDateTime(realtime) <= getRestaurant.alcoholStop & TimeOnly.FromDateTime(realtime) <= getRestaurant.alcoholStop)
            {
                menus.Add(getRestaurant.alcohol);
            }

            return menus;
        }

        private void onTick(object sender, EventArgs e)
        {
            realtime = DateTime.Now;
            txtUpdateClock.Text = realtime.Hour.ToString() + ":" + realtime.Minute.ToString() + ":" + realtime.Second.ToString();
        }

        private void cmbRestaurantName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            Restaurant getRestaurant = cmbRestaurantName.SelectedItem as Restaurant;
            if (getRestaurant != null)
            {
                txtUpdateID.Text = getRestaurant.id.ToString();
                txtUpdateName.Text = getRestaurant.name.ToString();
                txtUpdateOpeningTime.Text = getRestaurant.openingTime.ToString();
                txtUpdateClosingTime.Text = getRestaurant.closingTime.ToString();
                txtUpdateBreakfastStart.Text = getRestaurant.breakfastStart.ToString();
                txtUpdateBreakfastStop.Text = getRestaurant.breakfastStop.ToString();
                txtUpdateLunchStart.Text = getRestaurant.lunchStart.ToString();
                txtUpdateLunchStop.Text = getRestaurant.lunchStop.ToString();
                txtUpdateDinnerStart.Text = getRestaurant.dinnerStart.ToString();
                txtUpdateDinnerStop.Text = getRestaurant.dinnerStop.ToString();
                txtUpdateAlcoholStart.Text = getRestaurant.alcoholStart.ToString();
                txtUpdateAlcoholStop.Text = getRestaurant.alcoholStop.ToString();



                lstCurrentMenu.ItemsSource = grabItems();

                lstBreakfast.ItemsSource = getRestaurant.breakfast.items;
                lstLunch.ItemsSource = getRestaurant.lunch.items;
                lstDinner.ItemsSource = getRestaurant.dinner.items;
                lstHotDrinks.ItemsSource = getRestaurant.hotDrink.items;
                lstAlcoholicDrinks.ItemsSource = getRestaurant.alcohol.items;

            }
        }

        private void btnNewRestaurant_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<NewRestaurant>().Count() == 0)
            {
                NewRestaurant newRestaurant = new NewRestaurant();
                newRestaurant.Owner = this;
                newRestaurant.Show();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void btnNewMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<NewMenu>().Count() == 0)
            {
                NewMenu newMenu = new NewMenu();
                newMenu.Owner = this;
                newMenu.Show();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }


        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<NewItem>().Count() == 0)
            {
                NewItem newItem = new NewItem();
                newItem.Owner = this;
                newItem.Show();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
