using AnimeMe.Helpers;
using AnimeMe.Networking.NetworkModels.Anime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimeMe.ViewModels.Discover.Anime
{
    class AnimeFeedViewModel : BaseViewModel
    {

        ObservableCollection<AnimeFeedDetail> feed = new ObservableCollection<AnimeFeedDetail>();
        public ObservableCollection<AnimeFeedDetail> Feed
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
                feed.Clear();
                foreach(AnimeFeedDetail afd in results.data)
                {
                    feed.Add(afd);
                }
            }
        }

        public async void OnAnimeSubmit(string animeNameEN, string animeNameJP, string releaseDate, string animeImage)
        {
            
        }
    }
}
