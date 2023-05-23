using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGUIProject
{
    internal class Restaurant
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public TimeOnly openingTime { get; private set; }
        public TimeOnly closingTime { get; private set; }
        public TimeOnly breakfastStart { get; private set; }
        public TimeOnly breakfastStop { get; private set; }
        public TimeOnly lunchStart { get; private set; }
        public TimeOnly lunchStop { get; private set; }
        public TimeOnly dinnerStart { get; private set; }
        public TimeOnly dinnerStop { get; private set; }
        public TimeOnly alcoholStart { get; private set; }
        public TimeOnly alcoholStop { get; private set; }
        public Menu breakfast { get; private set; }
        public Menu lunch { get; private set; }
        public Menu dinner { get; private set; }
        public Menu alcohol { get; private set; }
        public Menu hotDrink { get; private set; }

        public Restaurant(int id, string name, TimeOnly openingTime, TimeOnly closingTime, TimeOnly breakfastStart, TimeOnly breakfastStop, TimeOnly lunchStart, TimeOnly lunchStop, TimeOnly dinnerStart, TimeOnly dinnerStop, TimeOnly alcoholStart, TimeOnly alcoholStop, Menu breakfast, Menu lunch, Menu dinner, Menu alcohol, Menu hotDrink)
        {
            this.id = id;
            this.name = name;
            this.openingTime = openingTime;
            this.closingTime = closingTime;
            this.breakfastStart = breakfastStart;
            this.breakfastStop = breakfastStop;
            this.lunchStart = lunchStart;
            this.lunchStop = lunchStop;
            this.dinnerStart = dinnerStart;
            this.dinnerStop = dinnerStop;
            this.alcoholStart = alcoholStart;
            this.alcoholStop = alcoholStop;
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
            this.alcohol = alcohol;
            this.hotDrink = hotDrink;
        }
    }
}
