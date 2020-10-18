using AnimeMe.Helpers;
using AnimeMe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AnimeMe.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        LoginHelper helper;

        public RegisterViewModel()
        {
            helper = new LoginHelper();
        }

        public async void OnSubmitClicked(string email, string username, string password, string confirmPassword)
        {
            if (email == string.Empty || username == string.Empty || password == string.Empty || confirmPassword == string.Empty)
            {
                await Shell.Current.DisplayAlert("Empty Entries", "All entries must be non-empty", "Ok");
                return;
            }

            if(password != confirmPassword)
            {
                await Shell.Current.DisplayAlert("Password Mismatch", "Both passwords must be the same.", "Ok");
                return;
            }

            var response = await helper.postRegister(email, username, password);
            if(response.statusCode != 0)
            {
                await Shell.Current.DisplayAlert("Register Error", response.message, "Ok");
            }
            await Shell.Current.GoToAsync($"//{nameof(AnimeMe.Views.Discover.DiscoverPage)}");
        }
    }
}
