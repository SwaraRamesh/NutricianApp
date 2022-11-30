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
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        Person _person;
        public LoginUI(Person person)
        {
            InitializeComponent();
            //DisplayAlert("EDITSSSSs", "Edit?", "yes", "no");
            Title = "Edit Info";
            _person = person;
            txtUsername.Text = person.Username;
            txtPassword.Text = "" + person.Password;
            txtPassword.Focus();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            //TODO: need to encrypt userID/passwordx
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            //if (txtUsername.Text.Equals(txtUsername) && txtPassword.Text.Equals(txtPassword))
            {
                
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert($"Username is {txtUsername.Text}", "yes", "no");
                DisplayAlert("Oops...", "Username or Password is incorrect!", "OK!");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        /*async void OnButtonClicked(object sender, EventArgs e)
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
            }
        }


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