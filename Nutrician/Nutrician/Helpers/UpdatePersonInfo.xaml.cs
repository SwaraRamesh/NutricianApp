using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePersonInfo : ContentPage
    {
        Person _person;

        public UpdatePersonInfo()
        {
            InitializeComponent();
        }

        public UpdatePersonInfo(Person person)
        {
            InitializeComponent();

            Application.Current.Properties["Username"] = txtUsername.Text;
            _person = person;
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

            var nextPage = new TabbedPageView();
            nextPage.BindingContext = _person;
            await Navigation.PushAsync(nextPage);
        }
    }//

}