using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician.Models
{
    public class MedicalCondition
    {
        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int ID { get; set; }
        //[Unique]
        public string Name { get; set; }
        public string Suggestions { get; set; }
        public string Avoid { get; set; }
        public string Meals { get; set; }
        public string VeganMeals { get; set; }
        //public string LactoseIntolerant { get; set; }

       /* public MedicalCondition(string name, string[] suggestions, string[] avoid, string[] meals, string[] veganMeals, string[] lactoseIntolerant)
        {
            this.name = name;
            this.suggestions = suggestions;
            this.avoid = avoid;
            this.meals = meals;
            this.veganMeals = veganMeals;
            this.lactoseIntolerant = lactoseIntolerant;
        }*/
    }
}
