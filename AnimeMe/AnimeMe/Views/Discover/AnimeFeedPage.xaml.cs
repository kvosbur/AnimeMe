using AnimeMe.ViewModels.Discover.Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimeMe.Views.Discover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimeFeedPage : ContentPage
    {
        AnimeFeedViewModel viewModel;

        public AnimeFeedPage()
        {
            InitializeComponent();
            viewModel = new AnimeFeedViewModel();
            BindingContext = viewModel;

            viewModel.setupFeed();
        }

        private void OnAnimeSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}