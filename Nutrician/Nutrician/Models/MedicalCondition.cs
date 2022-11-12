using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician.Models
{
    public class MedicalCondition
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string suggestions { get; set; }
        public string avoid { get; set; }
        public string meals { get; set; }
        public string veganMeals { get; set; }
        public string lactoseIntolerant { get; set; }

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
