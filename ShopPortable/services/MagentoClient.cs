using System;
namespace ShopPortable.services
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;

    public class MagentoClient
    {
        private static  String relativePath4LoginAsAdmin = "rest/V1/integration/admin/token";
        private string baseUri;

        public string Token
        {
            get;
            set;
        }

        public MagentoClient(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public async void loginAsAdminAsync(String username, String password)
        {
            String uri = baseUri + "/" + relativePath4LoginAsAdmin;
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

            Token = jsonResult;


        }

        public  MagentoClient loginAsAdmin(String username, String password)
        {
            String uri = baseUri + "/" + relativePath4LoginAsAdmin;
            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add("username", username);
            data.Add("password", password);

            string jsonData = JsonConvert.SerializeObject(data);

            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(uri);

            //var jsonObject =  new JsonObject()
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(uri, content);
            //response.EnsureSuccessStatusCode();
            var jsonResult = response.Result.Content.ReadAsStringAsync().Result;


            Token = JsonConvert.DeserializeObject<String>(jsonResult);

            return this;

        }
    }
}
