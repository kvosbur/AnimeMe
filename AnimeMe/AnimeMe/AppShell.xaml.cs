using System;
using System.Collections.Generic;
using AnimeMe.ViewModels;
using AnimeMe.Views;
using AnimeMe.Views.Profile;
using Xamarin.Forms;

namespace AnimeMe
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            //Routing.RegisterRoute("discover/edit", typeof(AnimeMe.Views.Profile.EditPage));
            Routing.RegisterRoute("profile/addAnime", typeof(AddAnimePage));
        }

    }
}
