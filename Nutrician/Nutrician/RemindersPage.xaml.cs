using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemindersPage : ContentPage
    {
        //DateTime datePicked;
        //TimeSpan timePicked;
        public RemindersPage()
        {
            InitializeComponent();
            //Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public void MyListButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }

        void datePickerHandler(object sender, DateChangedEventArgs args)
        {
            DisplayAlert("Time Picked", datePicked.Date.ToString(), "Ok");
            timePicked.Focus();
        }

        public void timePickerHandler(object sender, EventArgs e)
        {
            DisplayAlert("Time Picked", timePicked.Time.ToString(), "Ok");

        }

        /*bool OnTimerTick2()
        {
            var datePickerDate = datePicker.Date;
            DateTime date = DateTime.Now;
            if (_switch.IsToggled && datePickerDate >= date) {

                _switch.IsToggled = false;
            }
            if (_switch2.IsToggled && DateTime.Now.TimeOfDay <= timePicker.Time)
            {
                _switch2.IsToggled = false;
                DisplayAlert("Timer Alert", entryMessage.Text, "OK");
            }
            return true;
        }

        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now.TimeOfDay >= timePicker.Time)
            {
                _switch.IsToggled = false;
                DisplayAlert("Timer Alert", entryMessage.Text, "OK");
            }
            return true;
        }*/
    }
}