using System;
using System.Collections.Generic;

namespace ShopPortable.model
{
    public class Category
    {
        public long id { get; set; } = 2;
        public long parent_id { get; set; } = 1;
        public String name { get; set; } = "Category Store Group 1 - website_id_1";
        public bool is_active { get; set; } = true;
        public int position { get; set; } = 1;

        public int level { get; set; } = 1;
        public int product_count { get; set; } = 25;

        public List<CategoryAttribute> custom_attributes { get; set; } = new List<CategoryAttribute>();


        public List<Category> children_data { get; set; }= new List<Category>();

        public Category()
        {

        }
    }
}
