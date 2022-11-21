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
            String avoidHeartDisease = "heartsss";//{ "oil", "salt", "excessive carbs" };
            String avoidKidneyStones = "avoidkidney";//{ "salt", "oil", "greens like XXX" };
            //String avoidAnemia = "anemiaAgain";//{ "blood thinners like XXX", "oil" };
            String suggestionsHeartDisease = "Medicinal- Aspirin, ACE inhibitors/beta-blockers, Medications to lower high blood pressure and high cholesterol,major risk factors of coronary disease";//{ "nuts", "fiber", "cardio" };
            String suggestionsKidneyStones = "kidneys";//{ "nuts", "beans", "fiber" };
            //String suggestionsAnemia = "iron";//{ "reds like pomegranate", "beet root", "water" };
            String meals = "pizza";//{ "Pasta", "Pizza" };
            String veganMeals = "veganmeals";//{ "Vegan Pasta", "Rotis" };
            String lactoseIntolerantMeals = "lactose";//{ "MNM", "milk-less chapati" };
            List<MedicalCondition> conditions = new List<MedicalCondition>();
            conditions.Add(new MedicalCondition { Name = "Heart Disease",Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = meals, VeganMeals=veganMeals, LactoseIntolerant = lactoseIntolerantMeals});
            conditions.Add(new MedicalCondition { Name="Kidney Stones", Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = meals, VeganMeals = veganMeals, LactoseIntolerant = lactoseIntolerantMeals});
            //using (Task<int> task =
            App.Database.SaveAllConditionsAsync(conditions);// { }//
            //App.Database.DeleteAllConditionsAsync(conditions);
        }

        /*public async Task DeleteAllConditions() {
            await App.Database.DeleteAllConditionsAsync();
        }*/
    }
}
