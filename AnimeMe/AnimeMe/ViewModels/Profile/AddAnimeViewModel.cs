using AnimeMe.Helpers;
using AnimeMe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AnimeMe.ViewModels
{
    public class AddAnimeViewModel : BaseViewModel
    {
        AnimeHelper helper;

        public AddAnimeViewModel()
        {
            helper = new AnimeHelper();
        }

        public async void OnAnimeSubmit(string animeNameEN, string animeNameJP, string releaseDate, string animeImage)
        {
            if (animeNameEN == string.Empty && animeNameJP == string.Empty)
            {
                await Shell.Current.DisplayAlert("Empty Entries", "Must input an anime title", "Ok");
                return;
            }

            if(releaseDate == string.Empty || animeImage == string.Empty)
            {
                await Shell.Current.DisplayAlert("Empty Entries", "Release Date and Anime Image Url must not be emtpy", "Ok");
                return;
            }

            var response = await helper.postDetail(animeNameEN, animeNameJP, releaseDate, animeImage);
            if(response != null)
            {
                await Shell.Current.DisplayAlert("Anime Submition Error", response, "Ok");
                return;
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}
