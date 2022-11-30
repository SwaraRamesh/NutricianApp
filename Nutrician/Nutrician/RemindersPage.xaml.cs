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
    public partial class RemindersPage : ContentPage
    {
        public RemindersPage()
        {
            InitializeComponent();
        }

        public void HomeButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public void MyListButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyListPage());
        }
        
    }
}