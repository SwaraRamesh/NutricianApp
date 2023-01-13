using System;
using System.Collections.Generic;
using Nutrician.Models;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Xamarin.Forms;

namespace Nutrician
{	
	public partial class DisplayCondition : ContentPage
	{
        string username;
		public DisplayCondition ()
		{
			InitializeComponent ();
            username = Application.Current.Properties["Username"].ToString();

        }
        MedicalCondition _medicalCondition;
        MyList _myList;
        //Person _person;

        public DisplayCondition(MedicalCondition condition, string username)//Person person)
        {
            InitializeComponent();
            Name.Text = condition.Name;
            Suggestions.Text = condition.Suggestions;
            Avoid.Text = condition.Avoid;
            //_person = person;
            /*DisplayAlert("Ok?", $"{condition.Name}", "yes", "no");
            _medicalCondition.Name = condition.Name;
            _medicalCondition.Suggestions = condition.Suggestions;
            _medicalCondition.ID = condition.ID;
            _medicalCondition.Avoid = condition.Avoid;
            _medicalCondition.Meals = condition.Meals;
            _medicalCondition.VeganMeals = condition.VeganMeals;
            //_medicalCondition.LactoseIntolerant = condition.LactoseIntolerant;*/
            //var ret = condition.Name;
            _medicalCondition = condition;
        }
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await DisplayAlert("alert", "alert", "yes", "no");
            //DeleteAllConditions();
            //collectionView.ItemsSource =
            //await App.Database.GetConditionName(_medicalCondition.Name, _medicalCondition.ID);
            
        }

        public async void AddToListButton(object sender, EventArgs e)
        {

            _myList = new MyList();
            _myList.medId = _medicalCondition.ID;
            _myList.Username = Application.Current.Properties["Username"].ToString();
            _myList.Name = _medicalCondition.Name;
            DisplayAlert("" + _myList.medId, _myList.Username, "ok");
            //collectionView.ItemsSource =
            
            //var nextPage = new MyListPage(_medicalCondition, _person);
            //nextPage.BindingContext = _person;
            await App.Database.SaveMyListAsync(_myList);
            
        }

        /*public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }*/

        public void ShareMessage(object sender, EventArgs e)
        {
            CrossShare.Current.Share(new ShareMessage
            {
                Title = "SHARE",
                Text = Name.Text + ": " + Suggestions.Text + "/n" + Avoid.Text
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayCondition(_medicalCondition, username));
        }

        /*async void DeleteAllConditions() {
            App.Database.DeleteAllConditionsAsync();
        }*/

    }
}

