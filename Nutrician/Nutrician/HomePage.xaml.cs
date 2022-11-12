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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetMedicalConditionAsync();
            await DisplayAlert("on appearing", "on appearing", "Yes", "No");
        }
        public void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }
        public void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RemindersPage());
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HeartDiseasePage());
        }
        private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KidneyStones());
        }
        private void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnemiaPage());
        }

    }
}