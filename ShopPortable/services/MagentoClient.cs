using System;
namespace ShopPortable.services
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;
    using ShopPortable.model;
    using System.Net.Http.Headers;
    using Newtonsoft.Json.Linq;

    public class MagentoClient
    {
        private static String relativePath4LoginAsAdmin = "rest/V1/integration/admin/token";
        private string baseUri;

        public const string STATUS_OK = "ok";
        public const string STATUS_FAILED = "failed";

        public string Status { get; set; }

        private static string relativePath4Categories = "rest/V1/categories";
        private static string relativePath4Products = "rest/V1/products";

        public ProductPage productPage = new ProductPage();
        public Category rootCategory = new Category();

        private Dictionary<string, Product> productsBySku = new Dictionary<string, Product>(); 
        private string username;
        private string password;
        private int maxProductToLoad;

        public string Token
        {
            get;
            set;
        }

        public string Result { get; set; }

        public MagentoClient(string baseUri, string username, string password, int maxProductToLoad = 500)
        {
            this.baseUri = baseUri;
            this.username = username;
            this.password = password;
            this.maxProductToLoad = maxProductToLoad;
            this.loginAsAdmin(username, password);
        }

        public void loadMasterData()
        {

            if (productPage.items.Count < 1 || rootCategory.children_data.Count < 1)
            {
                try
                {
                    productPage = GetProductPage(1, maxProductToLoad);

                    foreach(Product p in productPage.items){
                        productsBySku.Add(p.sku, p);
                    }


                    rootCategory = getRootCategories();
                    Result = "Master data loaded successfully";
                    Status = STATUS_OK;
                }
                catch (Exception e)
                {

                    Result = $"Failed to load master data. Please restart the app. \n Error Message: {e.Message}";
                    Status = STATUS_FAILED;
                }
            }


        }

        public Product getProductBySku(string sku){
            Product product = new Product();
           // productsBySku.TryGetValue(sku, out product);

            if(productsBySku.ContainsKey(sku)){
                product = productsBySku[sku];
            }

            return product;
        }


        /*
         * Load master product and category data for later use
         * 
         */
        public MagentoClient loginAsAdmin(String username, String password)
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

        public string getJson(string uri)
        {
            string result = "";

            if (!String.IsNullOrEmpty(Token))
            {
                Dictionary<String, String> data = new Dictionary<string, string>();
                data.Add("Authorization", "Bearer " + Token);

                string jsonData = JsonConvert.SerializeObject(data);

                HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var response = httpClient.GetAsync(uri);
                result = response.Result.Content.ReadAsStringAsync().Result;

            }



            return result;
        }

        public Category getRootCategories()
        {
            int pageIndex = 0;
            int pageSize = 1000;
            String uri = baseUri + "/" + relativePath4Categories
                    + "?searchCriteria[currentPage]=" + pageIndex
                    + "&searchCriteria[pageSize]=" + pageSize;
            String json = getJson(uri);

            return JsonConvert.DeserializeObject<Category>(json);
        }

        private Category getCategoryByIdWithChildren(Category topLevelCategory, long id)
        {
            if (topLevelCategory.id == id)
            {
                return topLevelCategory;
            }

            foreach (Category child in topLevelCategory.children_data)
            {
                Category x_ = getCategoryByIdWithChildren(child, id);
                if (x_ != null)
                {
                    return x_;
                }
            }
            return null;
        }

        public Category getCategoryById(long categoryId)
        {

            Category category = getCategoryByIdWithChildren(rootCategory, categoryId);

            return category;
        }

        public ProductPage GetProductPage(int pageIndex, int pageSize)
        {
            string uri = baseUri + "/" + relativePath4Products
                    + "?searchCriteria[currentPage]=" + pageIndex
                    + "&searchCriteria[pageSize]=" + pageSize;
            string json = getJson(uri);


            return JsonConvert.DeserializeObject<ProductPage>(json);
        }

        public List<Product> searchProducts(String query)
        {
            List<Product> products = new List<Product>();

            foreach (Product product in productPage.items)
            {

                String name = product.name.ToLower();
                String queryLoweCase = query.ToLower();

                if (name.Contains(query)){
                    products.Add(product);

                }
            }

            return products;
        }

        public List<Product> getProductsInCategoryByCategoyId(long categoryId)
        {
            List<Product> products = new List<Product>();

            foreach (Product product in productPage.items)
            {
                foreach (MagentoAttribute magentoAttr in product.custom_attributes)
                {
                    if (magentoAttr.attribute_code.Equals("category_ids"))
                    {

                        String strCatId = $"{categoryId}";

                        JArray catIds = (JArray) magentoAttr.value;

                        foreach(String catId in catIds){
                            if(strCatId.Equals(catId)){
                                products.Add(product);
                                break;
                            }
                        }

                    }
                }

            }

            return products;
        }


    }
}
