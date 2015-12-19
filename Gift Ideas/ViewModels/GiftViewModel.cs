﻿namespace Gift_Ideas.ViewModels
{
    using System;
    using Windows.UI.Xaml.Controls;

    public class GiftViewModel
    {
        public string Title { get; set; }

        public Uri Image { get; set; }

        public string Price { get; set; }

        public string Shop { get; set; }

        public string TargetPerson { get; set; }

        public string Age { get; set; }
    }
}
