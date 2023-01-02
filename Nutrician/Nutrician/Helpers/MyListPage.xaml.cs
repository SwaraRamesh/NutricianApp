using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPage : ContentPage
    {
        Person _person;
        Models.MedicalCondition _condition;
        public MyListPage()
        {
            InitializeComponent();
            

        }

        public MyListPage(Models.MedicalCondition condition, Person person)
        {
            _condition = condition;
            _person = person;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await DisplayAlert("Ok?", "Hello", "yes", "no");
            //DeleteAllConditions();\collectionView.ItemsSource = await App.Database.GetMedicalConditionAsync();
            collectionView.ItemsSource = await App.Database.GetMyList();
        }

        public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public void ReminderButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}