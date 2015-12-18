namespace Gift_Ideas.Controls
{
    using Pages;
    using Parse;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class NavigationUserControl : UserControl
    {
        public NavigationUserControl()
        {
            this.InitializeComponent();
        }

        private void OnHomeButtonClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(ListGiftsPage), null);
        }

        private void OnLogoutButtonClick(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            ((Frame)Window.Current.Content).Navigate(typeof(LoginPage), null);
        }
    }
}
