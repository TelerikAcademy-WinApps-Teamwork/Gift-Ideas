namespace Gift_Ideas.ViewModels
{
    using System.Linq;
    using Models;
    using Parse;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class GiftListViewModel : ViewModelBase
    {
        private ObservableCollection<GiftViewModel> gifts;

        public GiftListViewModel()
        {
            this.LoadGifts();
        }

        private async void LoadGifts()
        {
            var gifts = await new ParseQuery<GiftModel>().FindAsync();

            this.Gifts = gifts.AsQueryable().Select(model => new GiftViewModel
            {
                Title = model.Title,
                Price = model.Price,
                Shop = model.Shop,
                TargetPerson = model.TargetPerson,
                Age = model.TargetPersonAge,
                Image = model.Image.Url
            });
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
