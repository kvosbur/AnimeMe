using AnimeMe.Helpers;
using AnimeMe.Networking.NetworkModels.Anime;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeMe.ViewModels.Discover.Anime
{
    class AnimeFeedViewModel : BaseViewModel
    {

        AnimeFeed feed = null;
        public AnimeFeed Feed
        {
            get { return feed; }
            set { SetProperty(ref feed, value); }
        }

        AnimeHelper helper;

        public AnimeFeedViewModel()
        {
            helper = new AnimeHelper();
        }

        public async void setupFeed()
        {
            var results = await helper.getAnimeFeed("", "");
            if (results != null)
            {
                feed = results;
            }
        }

        public async void OnAnimeSubmit(string animeNameEN, string animeNameJP, string releaseDate, string animeImage)
        {
            
        }
    }
}
