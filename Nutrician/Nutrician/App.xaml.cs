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
            //App.database.dropTableMyList();
            createMedicalConditions();
            //App.database.DeleteAllMyList();
            App.database.DeleteAllConditionsAsync();
            //MainPage = new MainPage();

            MainPage = new NavigationPage(new LoginUI());
            //MainPage = new NavigationPage(new TabbedPageView());
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
            String symptomsHeartDisease = "\n- Discomfort/heaviness/pain in chest or left arm\n- Fullness, indigestion, choking feeling (heartburn)\n- Sweating, nausea, vomiting dizziness\n- Constant weakness, anxiety, shortness of breath\n- Rapid or irregular heartbeats";
            String suggestionsHeartDisease = "MEDICINAL:\n- Aspirin\n- ACE inhibitors/beta-blockers\n- Medications to lower high blood pressure and high cholesterol\n- major risk factors of coronary disease";//{ "nuts", "fiber", "cardio" };
            String avoidHeartDisease = "- butter\n- gravy\n- non-dairy creamers\n- fried foods\n- processed meats\n- pastries\n- certain cuts of meat\n- junk foods, like potato chips, cookies, pies, and ice cream";//{ "oil", "salt", "excessive carbs" };
            String mealsHeartDisease = "pizza";//{ "Pasta", "Pizza" };

            String symptomsKidneyStones = "Stay extra hydrated, eat moderate amount of protein";//{ \"nuts\", \"beans\", \"fiber\" };\n";
            String suggestionsKidneyStones = "Stay extra hydrated, eat moderate amount of protein";//{ "nuts", "beans", "fiber" };
            String avoidKidneyStones = "Avoid cola, high salt intake, high calcium intake, and avoid oxalates like chocolate, beets, nuts, tea, spinach, sweet potatoes";//{ "salt", "oil", "greens like XXX" };
            String mealsKidneyStones = "fruit salad, orange juice/oranges, ";

            String symptomsAnemia = "- Fatigue\n- Weakness\n- Pale or yellowish skin\n- Irregular heartbeats\n- Shortness of breath\n- Dizziness or lightheadedness\n- Chest pain\n- Cold hands and feet\n- Headaches";
            String avoidAnemia = "Tea and coffee\n- milk and some dairy products\n- foods that contain tannins, such as grapes, corn, and sorghum\n- foods that contain phytates or phytic acid, such as brown rice and whole-grain wheat products\n- foods that contain oxalic acid, such as peanuts, parsley, and chocolate";//{ "blood thinners like XXX", "oil" };
            String suggestionsAnemia = "Iron Supplements\n- pomegranate or beet root";//{ "red fruit/vegetables like pomegranate or beet root", "water" };
            String veganMeals = "veganmeals";//{ "Vegan Pasta", "Rotis" };
            //String lactoseIntolerantMeals = "lactose";//{ "MNM", "milk-less chapati" };
            List<MedicalCondition> conditions = new List<MedicalCondition>();
            //List<MyList> list = new List<MyList>();
            List<UserNote> userNotes = new List<UserNote>();
            //****** make a loop to make/add instances of Medical Condition to the conditions list

            conditions.Add(new MedicalCondition { Name = "Heart Disease", Symptoms = symptomsHeartDisease, Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals=veganMeals});
            conditions.Add(new MedicalCondition { Name= "Kidney Stones", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsKidneyStones, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Diarrhea", Symptoms = symptomsHeartDisease, Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Diabetes", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Anemia", Symptoms = symptomsHeartDisease, Suggestions = suggestionsAnemia, Avoid = avoidAnemia, Meals = "Beet root fried rice", VeganMeals = "veganMeals"});
            conditions.Add(new MedicalCondition { Name = "Stomach Ulcer", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Coronavirus (COVID-19)", Symptoms = symptomsHeartDisease, Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Irritable Bowel Syndrome (IBS)", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsKidneyStones, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Constipation", Symptoms = symptomsHeartDisease, Suggestions = suggestionsHeartDisease, Avoid = avoidHeartDisease, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Flu", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals});
            conditions.Add(new MedicalCondition { Name = "Obesity", Symptoms = symptomsHeartDisease, Suggestions = suggestionsAnemia, Avoid = avoidAnemia, Meals = "Beet root fried rice", VeganMeals = "veganMeals"});
            conditions.Add(new MedicalCondition { Name = "HIV/AIDS", Symptoms = symptomsHeartDisease, Suggestions = suggestionsKidneyStones, Avoid = avoidKidneyStones, Meals = mealsHeartDisease, VeganMeals = veganMeals});

            //using (Task<int> task =
            App.Database.SaveAllConditionsAsync(conditions);// { }//
            //App.Database.DeleteAllAccountsAsync();
        }

    }
}
