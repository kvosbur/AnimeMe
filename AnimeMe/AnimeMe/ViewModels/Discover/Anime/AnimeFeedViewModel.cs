using AnimeMe.Helpers;
using AnimeMe.Networking.NetworkModels.Anime;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeMe.ViewModels.Discover.Anime
{
    class AnimeFeedViewModel : BaseViewModel
    {

        List<AnimeFeedDetail> feed = null;
        public List<AnimeFeedDetail> Feed
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
                feed = results.data;
            }
        }

        public async void OnAnimeSubmit(string animeNameEN, string animeNameJP, string releaseDate, string animeImage)
        {
            
        }
    }
}
