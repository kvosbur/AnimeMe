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
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
