﻿using AnimeMe.Helpers;
using AnimeMe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AnimeMe.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        LoginHelper helper;

        public LoginViewModel()
        {
            helper = new LoginHelper();
        }

        public async void OnLoginClicked(string username, string password)
        {
            if (username == string.Empty || password == string.Empty)
            {
                await Shell.Current.DisplayAlert("Empty Entries", "Username and Password must be non-empty", "Ok");
                return;
            }

            var response = await helper.postLogin(username, password);
            if(response.statusCode != 0)
            {
                await Shell.Current.DisplayAlert("Login Error", response.message, "Ok");
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
