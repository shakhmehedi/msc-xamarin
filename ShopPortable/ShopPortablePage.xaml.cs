using Xamarin.Forms;
using Newtonsoft.Json;
using ShopPortable.services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ShopPortable
{
    public partial class ShopPortablePage : ContentPage
    {

        // MagetoAccess magetoAccess = new MagetoAccess;
        public void onClicked(object sender, System.EventArgs e)
        {

            MagentoClient client = new MagentoClient("http://192.168.1.91");

            string token = client.loginAsAdmin("admin", "shakhmscpasS1]").Token;

            lblResult1.Text = token;

        }


        public ShopPortablePage()

        {
            
            InitializeComponent();
        }


    }
}
