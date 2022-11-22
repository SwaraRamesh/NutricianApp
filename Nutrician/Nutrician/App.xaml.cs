using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DatabaseEx.Droid;
using Nutrician.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician
{
    public partial class App : Application
    {
        private static MyDatabase database;

        public static MyDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            createMedicalConditions();
            //Delete

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new LoginUI());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        //
        public void createMedicalConditions()
        {
            String avoidHeartDisease = "sweets high in sugar/fats, meat";//{ "oil", "salt", "excessive carbs" };
            String avoidKidneyStones = "Avoid cola, high salt intake, high calcium intake, beets, nuts, tea, spinach, sweet potatoes";//{ "salt", "oil", "greens like XXX" };
            String avoidAnemia = "anemiaAgain";//{ "blood thinners like XXX", "oil" };
            String suggestionsHeartDisease = "Medicinal- Aspirin, ACE inhibitors/beta-blockers, Medications to lower high blood pressure and high cholesterol,major risk factors of coronary disease";//{ "nuts", "fiber", "cardio" };
            String suggestionsKidneyStones = "Stay extra hydrated, eat moderate amount of protein";//{ "nuts", "beans", "fiber" };
            String suggestionsAnemia = "iron";//{ "reds like pomegranate", "beet root", "water" };
            String mealsHeartDisease = "pizza";//{ "Pasta", "Pizza" };
            String mealsKidneyStones = "fruit salad, orange juice/oranges, ";
            String veganMeals = "veganmeals";//{ "Vegan Pasta", "Rotis" };
            String lactoseIntolerantMeals = "lactose";//{ "MNM", "milk-less chapati" };
            List<MedicalCondition> conditions = new List<MedicalCondition>();

            //****** make a loop to make/add instances of Medical Condition to the conditions list

            conditions.Add(new MedicalCondition { Name = "Heart Disease",Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals=veganMeals, LactoseIntolerant = lactoseIntolerantMeals});
            conditions.Add(new MedicalCondition { Name="Kidney Stones", Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsKidneyStones, VeganMeals = veganMeals, LactoseIntolerant = lactoseIntolerantMeals});
            conditions.Add(new MedicalCondition { Name = "Diarrhea", Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals = veganMeals, LactoseIntolerant = lactoseIntolerantMeals });
            conditions.Add(new MedicalCondition { Name = "Diabetes", Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals, LactoseIntolerant = lactoseIntolerantMeals });
            conditions.Add(new MedicalCondition { Name = "Anemia", Suggestions = "suggestionsAnemia", Avoid = "avoidAnemia", Meals = "mealsHeartDisease", VeganMeals = "veganMeals", LactoseIntolerant = "lactoseIntolerantMeals" });
            conditions.Add(new MedicalCondition { Name = "Stomach ulcer", Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals, LactoseIntolerant = lactoseIntolerantMeals });


            //using (Task<int> task =
            App.Database.SaveAllConditionsAsync(conditions);// { }//
            //App.Database.DeleteAllConditionsAsync();
        }

        /*public async Task DeleteAllConditions() {
            await App.Database.DeleteAllConditionsAsync();
        }*/
    }
}
