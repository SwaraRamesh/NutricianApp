using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimePicker = Xamarin.Forms.TimePicker;

namespace Nutrician
{
    public partial class ExTimePicker : ContentPage
    {
        public ExTimePicker()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now.TimeOfDay >= _timePicker.Time)
            {
                _switch.IsToggled = false;
                DisplayAlert("Timer Alert", entryMessage.Text, "OK");
            }
            return true;
        }
    }
}

