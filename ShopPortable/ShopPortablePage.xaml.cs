using Xamarin.Forms;
using Newtonsoft.Json;
using ShopPortable.services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopPortable.model;
using System.Collections.Generic;

namespace ShopPortable
{
    public partial class ShopPortablePage : ContentPage
    {
        public static MagentoClient Client { get; set; }


        // MagetoAccess magetoAccess = new MagetoAccess;
        public void onClicked(object sender, System.EventArgs e)
        {
            lblResult1.Text = "Loading master data. Pleasse wait";

            Client.loadMasterData();

            lblResult1.Text = $"Status: {Client.Status}. {Client.Result}";

            Category category = Client.getRootCategories();

            Category newCat = Client.getCategoryById(41L);

            List<Product> catProducts = Client.getProductsInCategoryByCategoyId(41L);

            lblResult2.Text = category.name;



        }


        public ShopPortablePage()

        {
            Client = new MagentoClient("http://192.168.1.91","admin","shakhmscpasS1]", 3000 );


            string token = Client.Token;

            InitializeComponent();
            lblResult1.Text = token;

        }


    }
}
