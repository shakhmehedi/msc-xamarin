using System;
using System.Collections.Generic;
using ShopPortable.model;
using Xamarin.Forms;

namespace ShopPortable.pages
{
    public partial class ProducDetailPage : ContentPage
    {
        void onSearchButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        public Product Product { get; set; }
        public ProducDetailPage(Product product)
        {
            this.Product = product;
            InitializeComponent();
            BindingContext = product;

        }
    }
}
