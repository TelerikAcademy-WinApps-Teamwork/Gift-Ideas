namespace Gift_Ideas.ViewModels
{
    using System.Linq;
    using Models;
    using Parse;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class GiftListViewModel : ViewModelBase
    {
        private ObservableCollection<GiftViewModel> gifts;
        private string areGiftsLoading;

        public GiftListViewModel()
        {
            this.AreGiftsLoading = "True";
            this.LoadGifts();
        }

        public string AreGiftsLoading
        {
            get { return this.areGiftsLoading; }

            set
            {
                if (value != this.areGiftsLoading)
                {
                    this.areGiftsLoading = value;
                    base.RaisePropertyChanged("AreGiftsLoading");
                }
            }
        }

        private async void LoadGifts()
        {
            var gifts = await new ParseQuery<GiftModel>().FindAsync();

            this.Gifts = gifts.AsQueryable().Select(model => new GiftViewModel
            {
                Title = model.Title,
                Price = model.Price.ToString(),
                Shop = model.Shop,
                TargetPerson = model.TargetPerson,
                Age = model.TargetPersonAge.ToString(),
                Image = model.Image.Url,
                Location = new double[] { model.Location.Latitude, model.Location.Longitude }
            });

            this.AreGiftsLoading = "False";
        }

        public IEnumerable<GiftViewModel> Gifts
        {
            get
            {
                if (this.gifts == null)
                {
                    this.gifts = new ObservableCollection<GiftViewModel>();
                }

                return this.gifts;
            }
            set
            {
                if (this.gifts == null)
                {
                    this.gifts = new ObservableCollection<GiftViewModel>();
                }

                this.gifts.Clear();
                foreach (var item in value)
                {
                    this.gifts.Add(item);
                }
            }
        }
    }
}
