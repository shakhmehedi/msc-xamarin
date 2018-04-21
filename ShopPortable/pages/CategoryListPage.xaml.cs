using System;
using System.Collections.Generic;
using ShopPortable.model;
using Xamarin.Forms;

namespace ShopPortable.pages
{
    public partial class CategoryListPage : ContentPage
    {
        void onSearchButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        void Handle_ItemTappedProduct(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            Navigation.PushAsync(new ProducDetailPage(product)); 
        }

        void Handle_ItemTappedCategory(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var category = e.Item as Category;
            Navigation.PushAsync(new CategoryListPage(category));        }

        public CategoryListPage(Category category)
        {
            InitializeComponent();


            Category categoryWithChildren = ShopPortablePage.Client.getCategoryById(category.id);

            if (categoryWithChildren.children_data.Count > 0)
            {
                listViewCategory.Header = $"{categoryWithChildren.name}";

                listViewCategory.ItemsSource = categoryWithChildren.children_data;
            }else{
                listViewCategory.IsVisible=false;
            }

            List<Product> catProducts = ShopPortablePage.Client.getProductsInCategoryByCategoyId(category.id);
            if(catProducts.Count > 0){
                listViewProduct.Header = $"{catProducts.Count} products found in \"{category.name}\"";
                listViewProduct.ItemsSource = catProducts;
            }else{
                listViewProduct.Header = $"No product found in \"{category.name}\" ";
            }



        }



    }
}
