namespace Gift_Ideas.Pages
{
    using ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class GiftDetailsPage : Page
    {
        public GiftDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var gift = e.Parameter as GiftViewModel;
            this.DataContext = gift;
        }
    }
}
