using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void OnGenderRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text==null || txtPassword.Text==null || txtFirstName.Text==null || txtEmail.Text==null)
            {
                DisplayAlert("Oops...", "One or more of the fields are empty!", "OK!");
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }
}