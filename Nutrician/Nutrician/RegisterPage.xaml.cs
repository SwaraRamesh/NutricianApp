using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using SQLite;

namespace Nutrician
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        Person _person;

        /*public RegisterPage(Person person)
        {
            InitializeComponent();

            DisplayAlert("EDITSSSSs", "Edit?", "yes", "no");
            Title = "Edit Info";
            _person = person;
            txtFirstName = person.FirstName;
            txtLastName.Text = person.LastName;
            txtFirstName.Focus();
        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await App.Database.GetPersonAsync();
        }

        void OnGenderRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //SavePerson();
            /*if (txtUsername.Text==null || txtPassword.Text==null || txtFirstName.Text==null || txtEmail.Text==null)
            {
                DisplayAlert("Oops...", "One or more of the fields are empty!", "OK!");
            }
            else
            {*/

            /*if (_person == null)
            {
                //result = await DisplayAlert("LLLLUpdate", "Update from the database", "Yes", "No");
                await App.Database.SavePersonAsync(new Person
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text
                });
            }*/
            /*else
            {*/
            //var res = sender as Person;
            //await DisplayAlert("EDIT", $"Edit {res.FirstName}??", "yes", "no");
            //_person = res;
            _person = new Person();
            _person.FirstName = txtFirstName.Text;
            _person.LastName = txtLastName.Text;
            _person.Email = txtEmail.Text;
            _person.Username = txtUsername.Text;
            _person.Password = txtPassword.Text;
            //txtUsername.Focus();
            
            App.Database.SavePersonAsync(_person);
            //}
            //txtFirstName.Text = txtLastName.Text = string.Empty;
            //collectionView.ItemsSource = await App.Database.GetPersonAsync();
            //res = await App.Database.GetPersonAsync();

            Navigation.PushAsync(new LoginUI());
            //}

        }

        /*public async void SavePerson()
        {
            await App.Database.SavePersonAsync(new Person
            {
                username = txtUsername.Text,
                password = txtPassword.Text
            });
        }*/

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
          //  Navigation.PushAsync(new RegisterPage());
        //}

    }
}