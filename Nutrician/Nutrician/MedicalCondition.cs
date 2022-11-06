using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician
{
    internal class MedicalCondition
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public String [] suggestions { get; set; }
        public String [] avoid { get; set; }
        public String [] meals { get; set; }
        public String [] veganMeals { get; set; }
        public String [] lactoseIntolerant { get; set; }

        public MedicalCondition(string name, string[] suggestions, string[] avoid, string[] meals, string[] veganMeals, string[] lactoseIntolerant)
        {
            this.name = name;
            this.suggestions = suggestions;
            this.avoid = avoid;
            this.meals = meals;
            this.veganMeals = veganMeals;
            this.lactoseIntolerant = lactoseIntolerant;
        }
    }
}
