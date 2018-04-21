using System;
using System.Collections.Generic;
using ShopPortable.model;
using Xamarin.Forms;


namespace ShopPortable.pages
{
    public partial class CategoryListContent : ContentView
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            var category = btn.CommandParameter as Category;
           // Navigation.PushAsync(new CategoryProductListPage(category));

        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var category = e.Item as Category;
            Navigation.PushAsync(new CategoryListPage(category));

        }

        public CategoryListContent(Category category)
        {
            Category categoryWithChildren = ShopPortablePage.Client.getCategoryById(category.id);
            InitializeComponent();

            if(categoryWithChildren.children_data.Count > 0){
                listViewCategory.ItemsSource = categoryWithChildren.children_data;
                lblResult2.Text = $"{categoryWithChildren.name}";
            }
        }
    }
}
