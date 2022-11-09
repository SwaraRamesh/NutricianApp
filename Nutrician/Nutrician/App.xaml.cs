﻿using System;
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
            String[] avoidKidneyStones = { "salt", "oil", "greens like XXX" };
            String[] avoidAnemia = { "blood thinners like XXX", "oil" };
            String[] suggestionsHeartDisease = { "nuts", "fiber", "cardio" };
            String[] suggestionsKidneyStones = { "nuts", "beans", "fiber" };
            String[] suggestionsAnemia = { "reds like pomegranate", "beet root", "water" };
            String[] meals = { "Pasta", "Pizza" };
            String[] veganMeals = { "Vegan Pasta", "Rotis" };
            String[] lactoseIntolerantMeals = { "MNM", "milk-less chapati" };
            List<MedicalCondition> conditions = new List<MedicalCondition>();
            conditions.Add(new MedicalCondition { name = "Heart Disease",suggestions = suggestionsHeartDisease, avoid = avoidHeartDisease, meals = meals, veganMeals=veganMeals, lactoseIntolerant = lactoseIntolerantMeals});
            conditions.Add(new MedicalCondition { name="Kidney Stones", suggestions = suggestionsKidneyStones, avoid = avoidKidneyStones, meals = meals, veganMeals = veganMeals, lactoseIntolerant = lactoseIntolerantMeals});
            using (Task<int> task = App.Database.SaveAllConditionsAsync(conditions)) { }
        }
    }
}
