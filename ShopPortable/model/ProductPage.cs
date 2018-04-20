using System;
using System.Collections.Generic;

namespace ShopPortable.model
{
    public class ProductPage
    {
        public List<Product> items { get; set; } = new List<Product>();
        public int total_count { get; set; } = 1000;
        public SearchCriteria search_criteria { get; set; } = new SearchCriteria();

        public ProductPage()
        {
        }
    }
}
