using System;
using System.Collections.Generic;
using ShopPortable.model;
using Xamarin.Forms;

namespace ShopPortable.pages
{
    public partial class SearchPage : ContentPage
    {
        void Handle_ItemTappedProduct(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            Navigation.PushAsync(new ProducDetailPage(product));
        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            var sb = sender as SearchBar;

            string query = sb.Text.ToString();
            updateSearchResult(query);

        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var sb = sender as SearchBar;

            string query = sb.Text.ToString();
            updateSearchResult(query);
        }

        public SearchPage(string query = " ")
        {
            InitializeComponent();
            updateSearchResult(query);
        }

        private void updateSearchResult(string query)
        {
            List<Product> products = ShopPortablePage.Client.searchProducts(query);

            if(products.Count > 0){
                listViewProduct.ItemsSource = products;
                if(" ".Equals(query)){
                    listViewProduct.Header = $"Showing all {products.Count} product(s). Start typing in search box.";

                }else{
                    listViewProduct.Header = $"{products.Count} product(s) found for keyword \"{query}\" ";

                }
            }else{
                listViewProduct.Header = $"No product found for keyword \"{query}\" ";

            }

        }
    }
}
