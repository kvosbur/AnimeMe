using System.ComponentModel;
using Xamarin.Forms;
using AnimeMe.ViewModels;

namespace AnimeMe.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}