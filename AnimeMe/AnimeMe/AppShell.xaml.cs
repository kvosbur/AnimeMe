using System;
using System.Collections.Generic;
using AnimeMe.ViewModels;
using AnimeMe.Views;
using Xamarin.Forms;

namespace AnimeMe
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute("discover/edit", typeof(AnimeMe.Views.Profile.EditPage));
            //Routing.RegisterRoute("profile", typeof(AnimeMe.Views.Profile.ProfilePage));
            //Routing.RegisterRoute("discover", typeof(AnimeMe.Views.Discover.DiscoverPage));
            //Routing.RegisterRoute("playlist", typeof(AnimeMe.Views.Playlist.PlaylistPage));
        }

    }
}
