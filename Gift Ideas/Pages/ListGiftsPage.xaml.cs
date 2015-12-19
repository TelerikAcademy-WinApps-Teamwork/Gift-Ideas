namespace Gift_Ideas.Pages
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ListGiftsPage : Page
    {
        public ListGiftsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                var message = e.Parameter as string;
                this.Toast.Message = message;
            }
        }
    }
}
