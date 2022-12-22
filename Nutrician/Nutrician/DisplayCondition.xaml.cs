using System;
using System.Collections.Generic;
using Nutrician.Models;

using Xamarin.Forms;

namespace Nutrician
{	
	public partial class DisplayCondition : ContentPage
	{	
		public DisplayCondition ()
		{
			InitializeComponent ();
            
            
		}
        MedicalCondition _medicalCondition;

        public DisplayCondition(MedicalCondition condition)
        {
            InitializeComponent();
            Name.Text = condition.Name;
            Suggestions.Text = condition.Suggestions;
            Avoid.Text = condition.Avoid;
            /*DisplayAlert("Ok?", $"{condition.Name}", "yes", "no");
            _medicalCondition.Name = condition.Name;
            _medicalCondition.Suggestions = condition.Suggestions;
            _medicalCondition.ID = condition.ID;
            _medicalCondition.Avoid = condition.Avoid;
            _medicalCondition.Meals = condition.Meals;
            _medicalCondition.VeganMeals = condition.VeganMeals;
            //_medicalCondition.LactoseIntolerant = condition.LactoseIntolerant;*/
            var ret = condition.Name;
        }
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await DisplayAlert("alert", "alert", "yes", "no");
            //DeleteAllConditions();
            //collectionView.ItemsSource =
            //await App.Database.GetConditionName(_medicalCondition.Name, _medicalCondition.ID);
            
        }

        public void AddToListButton(object sender, EventArgs e)
        {
            //collectionView.ItemsSource =
            App.Database.GetConditionName(_medicalCondition.Name, _medicalCondition.ID);
            Navigation.PushAsync(new DisplayCondition(_medicalCondition));
        }

        public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayCondition(_medicalCondition));
        }

        /*async void DeleteAllConditions() {
            App.Database.DeleteAllConditionsAsync();
        }*/

    }
}

