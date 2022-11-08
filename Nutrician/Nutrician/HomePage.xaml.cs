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
        MedicalCondition _MedCond;
        /*public HomePage(MedicalCondition MedCond)
        {
            InitializeComponent();

            DisplayAlert("EDITSSSSs", "Edit?", "yes", "no");
            Title = "Edit Info";
            _MedCond = MedCond;
            name.Text = MedCond.name;
            suggestions.Text = MedCond.suggestions;
            to-avoid.Text = MedCond.avoid;
            name.Focus();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            //var result = await DisplayAlert("add", $"Add {nameEntry.Text} from the database", "Yes", "No");
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                //result = await DisplayAlert("FFFFFUpdate", "Update from the database", "Yes", "No");


                if (_person == null)
                {
                    //result = await DisplayAlert("LLLLUpdate", "Update from the database", "Yes", "No");
                    await App.Database.SavePersonAsync(new Person
                    {
                        Name = nameEntry.Text,
                        Age = int.Parse(ageEntry.Text)
                    });
                }
                else
                {
                    _person.Name = nameEntry.Text;
                    _person.Age = int.Parse(ageEntry.Text);
                    //result = await DisplayAlert("TOUpdate", $"Update {_person.Name} from the database", "Yes", "No");
                    await App.Database.UpdatePersonAsync(_person);
                }
                nameEntry.Text = ageEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();


                nameEntry.Text = ageEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }*/

        public void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }
        public void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
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