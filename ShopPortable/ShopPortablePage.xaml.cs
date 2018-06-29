using Xamarin.Forms;
using Newtonsoft.Json;
using ShopPortable.services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopPortable.model;
using System.Collections.Generic;
using ShopPortable.pages;

namespace ShopPortable
{
    public partial class ShopPortablePage : ContentPage
    {
        private string jsonStringProduct;
        private string jsonStringCategory;

        void onSearchButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }


        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var category = e.Item as Category;
            Navigation.PushAsync(new CategoryListPage(category));

        }

        public static MagentoClient Client { get; set; }


        // MagetoAccess magetoAccess = new MagetoAccess;
        public void onClicked(object sender, System.EventArgs e)
        {
            lblResult1.Text = "Loading master data. Pleasse wait";

            Client.loadMasterData();

            lblResult1.Text = $"Status: {Client.Status}. {Client.Result}";






        }


        public ShopPortablePage(string jsonStringProduct, string jsonStringCategory)
        {
            this.jsonStringProduct = jsonStringProduct;
            this.jsonStringCategory = jsonStringCategory;



            InitializeComponent();

            Client = new MagentoClient("http://195.201.143.196", "admin", "shakhmscpasS1]", 3000);
            Client.loadMasterDataCache(this.jsonStringProduct, this.jsonStringCategory);
            lblResult1.Text = $"Status: {Client.Status}. {Client.Result}";
            Category category = Client.getRootCategories();

            listViewCategory.Header = $"{category.name} ({category.children_data.Count})";
            listViewCategory.ItemsSource = category.children_data;
        }

        public ShopPortablePage() { }

    }
}
