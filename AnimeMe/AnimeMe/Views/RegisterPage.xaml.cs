using AnimeMe.ViewModels;
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
        RegisterViewModel viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterViewModel();
            BindingContext = viewModel;
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            viewModel.OnSubmitClicked(Email.Text, Username.Text, Password.Text, ConfirmPassword.Text);
        }
    }
}