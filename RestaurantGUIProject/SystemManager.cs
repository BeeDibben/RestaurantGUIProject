using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGUIProject
{
    public class SystemManager
    {
        internal List<string> mealTypes = new List<string>() { "Hot Drink", "Breakfast", "Lunch", "Dinner", "Alcoholic Drink" };
        internal List<Item> defaultItems { get; private set; }
        internal List<Item> allItems { get; private set; }
        internal List<Menu> defaultMenus { get; private set; }
        internal List<Menu> allMenus { get; private set; }
        internal List<Restaurant> defaultRestaurants { get; private set; }
        internal List<Restaurant> allRestaurants { get; private set; }


        internal SystemManager()
        {
            this.defaultItems = new List<Item>();
            this.allItems = new List<Item>();
            this.defaultMenus = new List<Menu>();
            this.allMenus = new List<Menu>();
            this.defaultRestaurants = new List<Restaurant>();
            this.allRestaurants = new List<Restaurant>();

            InitialiseManger();
        }

        private void InitialiseManger()
        {
            AddDefaultItems();
            AddDefaultMenus();
            AddDefualtRestaurants();
            MirrorDefaults();
        }


        private void AddDefaultItems()
        {
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Black Coffee", Convert.ToDecimal(1.30), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Flat White", Convert.ToDecimal(1.50), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Latte", Convert.ToDecimal(1.60), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Hot Chocolate", Convert.ToDecimal(1.50), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Deluxe Hot Chocolate", Convert.ToDecimal(1.80), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Mocha", Convert.ToDecimal(1.70), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Deluxe Mocha", Convert.ToDecimal(1.90), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Breakfast Tea", Convert.ToDecimal(1.10), "Hot Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Herbal Tea", Convert.ToDecimal(1.10), "Hot Drink"));


            defaultItems.Add(new Item(defaultItems.Count() + 1, "Full English", Convert.ToDecimal(3.60), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Big Breakfast", Convert.ToDecimal(4.80), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Veggie Breakfast", Convert.ToDecimal(3.60), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Big Veggie Breakfast", Convert.ToDecimal(4.80), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Poached Eggs on toast", Convert.ToDecimal(3.40), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Scrambled Eggs on toast", Convert.ToDecimal(3.40), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Fried Eggs on toast", Convert.ToDecimal(3.40), "Breakfast"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Breakfast Wrap", Convert.ToDecimal(2.80), "Breakfast"));


            defaultItems.Add(new Item(defaultItems.Count() + 1, "Ham, Egg, and Chips", Convert.ToDecimal(4.20), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Brunch", Convert.ToDecimal(4.20), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Big Brunch", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Veggie Brunch", Convert.ToDecimal(4.20), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Big Veggie Brunch", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Ploughman's Sandwich", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Soup of the Day", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Panini", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Ploughman's Sandwich", Convert.ToDecimal(5.60), "Lunch"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Caesar Salad", Convert.ToDecimal(5.60), "Lunch"));



            defaultItems.Add(new Item(defaultItems.Count() + 1, "Chips", Convert.ToDecimal(2.60), "Dinner"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Cheesy Chips", Convert.ToDecimal(4.20), "Dinner"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Burger and Chips", Convert.ToDecimal(4.10), "Dinner"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Cheeseburger and Chips", Convert.ToDecimal(4.10), "Dinner"));


            defaultItems.Add(new Item(defaultItems.Count() + 1, "Whiskey", Convert.ToDecimal(3.00), "Alcoholic Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Gin", Convert.ToDecimal(2.80), "Alcoholic Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Vodka", Convert.ToDecimal(2.30), "Alcoholic Drink"));
            defaultItems.Add(new Item(defaultItems.Count() + 1, "Any mixer", Convert.ToDecimal(1.20), "Alcoholic Drink"));




        }

        private void AddDefaultMenus()
        {
            List<Item> hotDrinks = new List<Item>();
            foreach (Item item in defaultItems)
            {
                if (item.itemType == "Hot Drink")
                {
                    hotDrinks.Add(item);
                }
            }
            Menu defaultHotDrinks = new Menu(defaultMenus.Count() + 1, "DefaultHotDrinks", "Hot Drink", hotDrinks);
            this.defaultMenus.Add(defaultHotDrinks);



            List<Item> breakfastItems = new List<Item>();

            foreach (Item item in defaultItems)
            {
                if (item.itemType == "Breakfast")
                {
                    breakfastItems.Add(item);
                }
            }
            Menu defaultBreakfastMenu = new Menu(defaultMenus.Count() + 1, "DefaultBreakFast", "Breakfast", breakfastItems);
            this.defaultMenus.Add(defaultBreakfastMenu);



            List<Item> lunchItems = new List<Item>();
            foreach (Item item in defaultItems)
            {
                if (item.itemType == "Lunch")
                {
                    lunchItems.Add(item);
                }
            }
            Menu defaultLunchMenu = new Menu(defaultMenus.Count() + 1, "DefaultLunch", "Lunch", lunchItems);
            this.defaultMenus.Add(defaultLunchMenu);




            List<Item> dinnerItems = new List<Item>();
            foreach (Item item in defaultItems)
            {
                if (item.itemType == "Dinner")
                {
                    dinnerItems.Add(item);
                }
            }
            Menu defaultDinnerMenu = new Menu(defaultMenus.Count() + 1, "DefaultDinner", "Dinner", dinnerItems);
            this.defaultMenus.Add(defaultDinnerMenu);

            List<Item> alcoholicDrinks = new List<Item>();
            foreach (Item item in defaultItems)
            {
                if (item.itemType == "Alcoholic Drink")
                {
                    alcoholicDrinks.Add(item);
                }
            }
            Menu defaultAlcoholicDrinks = new Menu(defaultMenus.Count() + 1, "DefaultAlcoholicDrinks", "Alcoholic Drink", alcoholicDrinks);
            this.defaultMenus.Add(defaultAlcoholicDrinks);

        }

        private void AddDefualtRestaurants()
        {
            defaultRestaurants.Add(new Restaurant(defaultRestaurants.Count() + 1, "The Strong Arm", new TimeOnly(7, 30), new TimeOnly(22, 30), new TimeOnly(8, 00), new TimeOnly(11, 30), new TimeOnly(11, 00), new TimeOnly(14, 00), new TimeOnly(14, 00), new TimeOnly(21, 30), new TimeOnly(16, 00), new TimeOnly(22, 00), this.defaultMenus[1], this.defaultMenus[2], this.defaultMenus[3], this.defaultMenus[4], this.defaultMenus[0]));
            defaultRestaurants.Add(new Restaurant(defaultRestaurants.Count() + 1, "The Swan", new TimeOnly(8, 30), new TimeOnly(23, 00), new TimeOnly(8, 30), new TimeOnly(12, 00), new TimeOnly(11, 00), new TimeOnly(14, 00), new TimeOnly(14, 00), new TimeOnly(21, 30), new TimeOnly(16, 00), new TimeOnly(22, 30), this.defaultMenus[1], this.defaultMenus[2], this.defaultMenus[3], this.defaultMenus[4], this.defaultMenus[0]));
        }

        private void MirrorDefaults()
        {
            foreach (Item item in defaultItems)
            {
                allItems.Add(item);
            }
            foreach (Menu menu in defaultMenus)
            {
                allMenus.Add(menu);
            }
            foreach (Restaurant restaurant in defaultRestaurants)
            {
                allRestaurants.Add(restaurant);
            }
        }


    }
}
