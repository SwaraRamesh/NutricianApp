using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrician.Models;

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
            //collectionView.ItemsSource = App.Database.GetMedicalConditionAsync();
        }
        Person _person;

        public HomePage(Person person)
        {
            Title = "Edit Info";
            _person = person;
            //txtFirstName.Text = person.FirstName;
            //ageEntry.Text = person.LastName;
            //nameEntry.Focus();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //DeleteAllConditions();
            collectionView.ItemsSource = await App.Database.GetMedicalConditionAsync();
        }

        public async void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
            collectionView.ItemsSource = await App.Database.Search(e.NewTextValue);
        }

        public void MyListButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }
        public void RemindersButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RemindersPage());
        }

        public async void ConditionPageButton(object sender, EventArgs e)
        {
            var item = sender as Button;
            var res = item.CommandParameter as MedicalCondition;
            //await DisplayAlert("Ok?", $"{res.Name}", "yes", "no");
            //Navigation.PushAsync(new DisplayCondition(res));
            await Navigation.PushAsync(new DisplayCondition());
        }

        public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        public void EditRegistrationButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        
        async void EditInfo(Object sender, EventArgs e)
        {
            var item = sender as Button;
            var res = item.CommandParameter as Person;
            //await DisplayAlert("Edit", " invoked.", "OK","yes");

            await DisplayAlert("EDIT", $"Edit {res.FirstName}??", "yes", "no");
            _person = res;
            await Navigation.PushAsync(new RegisterPage());
        }
        


        /*async void DeleteAllConditions()
        {
            App.Database.DeleteAllConditionsAsync();
        }*/



        /*Person _person;
        //private MainPage res;
        public HomePage(MedicalCondition person)
        {
            InitializeComponent();

            DisplayAlert("EDITSSSSs", "Edit?", "yes", "no");
            Title = "Edit Info";
            _person = person;
            Username.Text = person.username;
            Password.Text = "" + person.password;
            username.Focus();
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



            /*if (_person != null)
            {
                result = await DisplayAlert("Update", $"Update {_person.Name} from the database", "Yes", "No");

                _person.Name = nameEntry.Text;
                _person.Age = int.Parse(ageEntry.Text);
                await App.Database.UpdatePersonAsync(_person);
            }
            else
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text)
                });
            }*/
        /*}


        async void SwipeItem_Edit(Object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var res = item.CommandParameter as Person;
            await DisplayAlert("EDIT", $"Edit {res.Name}??", "yes", "no");
            _person = res;
            nameEntry.Text = res.Name;
            ageEntry.Text = "" + res.Age;
            nameEntry.Focus();
            //await Navigation.PushAsync(new MainPage());
        }

        async void SwipeItem_Delete(Object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var res = item.CommandParameter as Person;
            var result = await DisplayAlert("Delete", $"Delete {res.Name} from the database", "Yes", "No");
            if (result)
            {
                await App.Database.DeletPersonAsync(res);
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }*/
    }
}