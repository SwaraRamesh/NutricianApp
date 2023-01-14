using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrician.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackerPage : ContentPage
    {
        Models.UserNote _userNote;
        public TrackerPage()
        {
            InitializeComponent();
            _userNote = new Models.UserNote();
            txtUserEntry.Focus();
        }

        /*public TrackerPage(Models.UserNote userNote)
        {
            InitializeComponent();
            _userNote = new Models.UserNote();
            _userNote = userNote;
            txtUserEntry.Focus();
        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await DisplayAlert("Ok?", "Hello", "yes", "no");
            //DeleteAllConditions();\collectionView.ItemsSource = await App.Database.GetMedicalConditionAsync();
            collectionView.ItemsSource = await App.Database.GetMyNotes();
        }

        /*async void SaveButton(Object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserEntry.Text))
            {
                //var res = await DisplayAlert("Save note?", "Would you like to save this note?", "yes", "no");
                //if (res)
                //{
                if (_userNote == null)
                {
                    await App.Database.SaveNoteAsync(new Models.UserNote
                    {
                        Note = txtUserEntry.Text
                    });
                }
                else
                {
                    _userNote.Note = txtUserEntry.Text;
                    await App.Database.UpdateNoteAsync(_userNote);
                }
                txtUserEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetMyNotes();
            }
            //}
        }*/

        async void SaveButton(object sender, EventArgs e)
        {
            //var result = await DisplayAlert("add", $"Add {nameEntry.Text} from the database", "Yes", "No");
            
                //result = await DisplayAlert("FFFFFUpdate", "Update from the database", "Yes", "No");

            if (_userNote.Note == null)
            {
                //result = await DisplayAlert("LLLLUpdate", "Update from the database", "Yes", "No");
                await App.Database.SaveNoteAsync(new Models.UserNote
                {
                    Note = txtUserEntry.Text
                });
            }
            else
            {
                _userNote.Note = txtUserEntry.Text;
                //result = await DisplayAlert("TOUpdate", $"Update {_person.Name} from the database", "Yes", "No");
                await App.Database.UpdateNoteAsync(_userNote);
            }
            txtUserEntry.Text = string.Empty;
            collectionView.ItemsSource = await App.Database.GetMyNotes();

            _userNote.Note = null;
        }


        /*async void DeleteButton(Object sender, EventArgs e)
        {
            var item = sender as Button;
            var res = item.BindingContext as Models.UserNote;
            if (res!= null)
            {
                var result = await DisplayAlert("Delete", $"Delete {res.Note} from the database", "Yes", "No");
                if (result)
                {
                    await App.Database.DeletNoteAsync(res);
                    listView.ItemsSource = await App.Database.GetMyNotes();
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var item = sender as TextCell;
            var res = item.BindingContext as Models.UserNote;
            var res2 = await DisplayAlert("EDIT", $"Edit {res.Note}??", "yes", "no");
            if (res2)
            {
                txtUserEntry.Text = res.Note;
                txtUserEntry.Focus();
            }
        }*/

        async void SwipeItem_Edit(Object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var res = item.CommandParameter as Models.UserNote;
            await DisplayAlert("EDIT", $"Edit {res.Note}??", "yes", "no");
            _userNote = res;
            txtUserEntry.Text = res.Note;
            txtUserEntry.Focus();
            //await Navigation.PushAsync(new MainPage());
        }

        async void SwipeItem_Delete(Object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var res = item.CommandParameter as Models.UserNote;
            var result = await DisplayAlert("Delete", $"Delete {res.Note} from the database", "Yes", "No");
            if (result)
            {
                await App.Database.DeletNoteAsync(res);
                collectionView.ItemsSource = await App.Database.GetMyNotes();
            }
        }
    }
}