using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPage : ContentPage
    {
        string username;
        //Person _person;
        //Models.MedicalCondition _condition;
        //MyList _myList;
        public MyListPage()
        {
            InitializeComponent();
            username = Application.Current.Properties["Username"].ToString();
            //listView.ItemsSource = await App.Database.GetMyList(_person.Username);
        }

        /*public MyListPage(Models.MedicalCondition condition, Person person, MyList my_list)
        {
            _condition = condition;
            _person = person;
            _myList = my_list;
        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await DisplayAlert("Ok?", username, "yes", "no");
            //DeleteAllConditions();\collectionView.ItemsSource = await App.Database.GetMedicalConditionAsync();
            listView.ItemsSource = await App.Database.GetMyList(username);
        }

        /*public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public void ReminderButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }*/
        /*void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayCondition());
        }*/
    }
}