namespace Gift_Ideas
{
    using Gift_Ideas.Pages;
    using Models;
    using Parse;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.IO;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (s, e) =>
            {
                this.HandleUserLogin();
            };
        }

        private void HandleUserLogin()
        {
            if (ParseUser.CurrentUser != null)
            {
                this.Frame.Navigate(typeof(ListGiftsPage), null);
            }
            else
            {
                this.Frame.Navigate(typeof(LoginPage), null);
            }
        }
    }
}
