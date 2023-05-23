using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGUIProject
{
    internal class Menu
    {

        // Variables //
        public int id { get; private set; }
        public string name { get; private set; }
        public string mealType { get; private set; }
        public List<Item> items { get; private set; }



        // Constructor //

        public Menu(int id, string name, string mealType, List<Item> items)
        {
            this.id = id;
            this.name = name;
            this.mealType = mealType;
            this.items = items;
        }


    }
}
