using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimeMe.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnimePage : ContentPage
    {
        public AddAnimePage()
        {
            InitializeComponent();
        }

        private void OnAnimeSubmit(object sender, EventArgs e)
        {
            var imageUrl = "https://images.pexels.com/users/avatars/322032/apalad-kun-474.jpeg?w=256&h=256&fit=crop&auto=compress";
        }
    }
}