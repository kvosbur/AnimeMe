using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimeMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked( object sender, EventArgs e)
        {
            // viewModel.OnLoginClicked(Username.Text, Password.Text);
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}