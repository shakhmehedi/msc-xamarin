using System;
namespace ShopPortable.ViewModel
{
    using Xamarin.Forms;
    using Newtonsoft.Json;
    using ShopPortable.services;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductViewModel
    {
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                NotifyPropertyChanged();
            }
        }
        private static String relativePath4LoginAsAdmin = "rest/V1/integration/admin/token";
        private string baseUri;



        public ProductViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async Task loginAsAdminAsync(String username, String password, string uri)
        {
             uri = uri + "/" + relativePath4LoginAsAdmin;
            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add("username", username);
            data.Add("password", password);

            string jsonData = JsonConvert.SerializeObject(data);

            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(uri);

            //var jsonObject =  new JsonObject()
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();
            var jsonResult = response.Content.ReadAsStringAsync().Result;

            //Token = JsonConvert.DeserializeObject<String>(jsonResult);



            Result = JsonConvert.DeserializeObject<String>(jsonResult);


        }
    }
}
