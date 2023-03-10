using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemindersPage : ContentPage
    {
        //DateTime datePicked;
        //TimeSpan timePicked;

        Models.Reminder _reminder;

        public RemindersPage()
        {
            InitializeComponent();
            //Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }



        public void SaveAlarm(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            DateTime dPicked = datePicked.Date;
            DateTime dt = new DateTime(dPicked.Year, dPicked.Month, dPicked.Day, timePicked.Time.Hours, timePicked.Time.Minutes, timePicked.Time.Seconds);
            TimeSpan timeToAlarm = dt - date;
            if (timeToAlarm.TotalSeconds <= 0)
            {
                DisplayAlert("Oops, you chose a time that has already passed! Select another time.", "Error", "OK");
            }
            else if (timeToAlarm.TotalSeconds > 0)
            {
                //DisplayAlert(entryMessage.Text, datePicked.Date.ToString(), "Ok");
                Device.StartTimer(timeToAlarm, () =>
                {
                    // do something every 60 seconds
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // interact with UI elements
                        DisplayAlert("Reminder", entryMessage.Text, "Ok");

                    });
                    return true; // runs again, or false to stop
                });
            }

        }

        public void AddReminderButton(object sender, EventArgs e)
        {
            App.Database.SaveReminderAsync(_reminder);
        }

        public async void DeleteReminderButton(object sender, EventArgs e)
        {
            await App.Database.DeletReminderAsync(_reminder);
        }

        void datePickerHandler(object sender, DateChangedEventArgs args)
        {
            //DisplayAlert("Time Picked", datePicked.Date.ToString(), "Ok");
            timePicked.Focus();
        }

        public void timePickerHandler(object sender, EventArgs e)
        {
            //DisplayAlert("Time Picked", timePicked.Time.ToString(), "Ok");

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
