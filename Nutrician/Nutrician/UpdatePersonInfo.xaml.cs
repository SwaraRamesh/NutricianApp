using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Nutrician
{
    public partial class UpdatePersonInfo : ContentPage
    {
        Person _person;

        public UpdatePersonInfo()
        {
            InitializeComponent();
        }

        public UpdatePersonInfo(Person p)
        {
            InitializeComponent();
            _person = p;
        }

        void OnGenderRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //_person = new Person();
            _person.FirstName = txtFirstName.Text;
            _person.LastName = txtLastName.Text;
            _person.Email = txtEmail.Text;
            _person.Password = txtPassword.Text;

            App.Database.UpdatePersonAsync(_person);

            var nextPage = new HomePage(_person);
            nextPage.BindingContext = _person;
            await Navigation.PushAsync(nextPage);
        }
    }//

}