using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
            String[] avoidHeartDisease = { "oil", "salt", "excessive carbs" };
            String[] avoidKidneyStones = { "salt", "oil", "greens like XXX"};
            String[] avoidAnemia = { "blood thinners like XXX", "oil"};
            String[] suggestionsHeartDisease = { "nuts", "fiber", "cardio"};
            String[] suggestionsKidneyStones = { "nuts", "beans", "fiber" };
            String[] suggestionsAnemia = { "reds like pomegranate", "beet root", "water"};
            String[] meals = { "Pasta", "Pizza"};
            String[] veganMeals = { "Vegan Pasta", "Rotis"};
            String[] lactoseIntolerantMeals = { "MNM", "milk-less chapati"};
            MedicalCondition cond1 = new MedicalCondition("Heart Disease", suggestionsHeartDisease, avoidHeartDisease, meals, veganMeals, lactoseIntolerantMeals);
        }
    }
}
