using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;

namespace ShopPortable.Droid
{
    [Activity(Label = "ShopPortable.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Read the contents of our asset
            string jsonStringProduct;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("products.json")))
            {
                jsonStringProduct = sr.ReadToEnd();
            }

            string jsonStringCategory;
            using (StreamReader sr = new StreamReader(assets.Open("categories.json")))
            {
                jsonStringCategory = sr.ReadToEnd();
            }


            LoadApplication(new App(jsonStringProduct, jsonStringCategory));
        }
    }
}
