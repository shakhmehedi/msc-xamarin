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

            //Client.loadMasterData();
            Client.loadMasterDataCache(this.jsonStringProduct, this.jsonStringCategory);

            lblResult1.Text = $"Status: {Client.Status}. {Client.Result}";

            Category category = Client.getRootCategories();

            Category newCat = Client.getCategoryById(14L);

            List<Product> catProducts = Client.getProductsInCategoryByCategoyId(21L);

            lblResult2.Text = category.name;

            listViewCategory.Header = $"{category.name} ({category.children_data.Count})";
            listViewCategory.ItemsSource = category.children_data;




        }


        public ShopPortablePage()

        {


        }

        public ShopPortablePage(string jsonStringProduct, string jsonStringCategory)
        {
            this.jsonStringProduct = jsonStringProduct;
            this.jsonStringCategory = jsonStringCategory;

            Client = new MagentoClient("http://192.168.1.91", "admin", "shakhmscpasS1]", 3000);


            string token = Client.Token;

            InitializeComponent();
            lblResult1.Text = token;
        }
    }
}
