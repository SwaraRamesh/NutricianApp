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
            Title = "Edit Info";
            _person = person;
            txtUsername.Text = person.Username;
            txtPassword.Text = "" + person.Password;
            txtUsername.Focus();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            Person person = null;
            try
            {
                
                person = App.Database.GetPersonByUsernameAsync(txtUsername.Text).Result;
                if (person == null)
                {
                    await DisplayAlert("Oops!", "Username does not exist. Please register or enter username again.", "OK");
                    txtUsername.Focus();
                    return;
                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex);
            }
            if (txtPassword.Text.Equals(person.Password))
            {
                Application.Current.Properties["Username"] = txtUsername.Text;
                await Navigation.PushAsync(new TabbedPageView());
            }
            else
            {
                await DisplayAlert("Oops...", "Username or Password is incorrect!", "OK!");
                txtUsername.Focus();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }
}