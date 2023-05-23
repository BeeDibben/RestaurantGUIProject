using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGUIProject
{
    internal class Item
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public decimal cost { get; private set; }
        public string itemType { get; private set; }


        public Item(int id, string name, decimal cost, string itemType)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.itemType = itemType;
        }

    }
}
