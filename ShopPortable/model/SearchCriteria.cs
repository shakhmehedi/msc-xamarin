using System;
using System.Collections.Generic;

namespace ShopPortable.model
{
    public class SearchCriteria
    {
        public List<FilterGroup> filter_groups { get; set; } = new List<FilterGroup>();
        public int page_size { get; set; } = 10;
        public int current_page { get; set; } = 0;
        public SearchCriteria()
        {
        }
    }
}
