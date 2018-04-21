using Xamarin.Forms;

namespace ShopPortable
{
    public partial class App : Application
    {
        private string jsonStringProduct;
        private string jsonStringCategory;

        

        public App()
        {


        }

        public App(string jsonStringProduct, string jsonStringCategory)
        {
            this.jsonStringProduct = jsonStringProduct;
            this.jsonStringCategory = jsonStringCategory;
            InitializeComponent();

            //MainPage = new ShopPortablePage();
            MainPage = new NavigationPage(new ShopPortablePage(jsonStringProduct,jsonStringCategory ));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
