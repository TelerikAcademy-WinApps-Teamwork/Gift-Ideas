namespace Gift_Ideas
{
    using Gift_Ideas.Pages;
    using Parse;
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
