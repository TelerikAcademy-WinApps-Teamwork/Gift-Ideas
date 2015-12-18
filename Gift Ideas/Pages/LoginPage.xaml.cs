namespace Gift_Ideas.Pages
{
    using Gift_Ideas.ViewModels;
    using Parse;
    using System;
    using System.Net;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void OnRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage), null);
        }

        private async void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var user = this.DataContext as UserLoginViewModel;

            try
            {
                await ParseUser.LogInAsync(user.Username, user.Password);
            }
            catch (WebException)
            {
                this.Toast.Message = "Invalid username or password!";
                return;
            }
            catch (Exception)
            {
                this.Toast.Message = "No internet connection!";
                return;
            }

            this.Frame.Navigate(typeof(ListGiftsPage), null);
        }
    }
}
