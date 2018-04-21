using System;
using System.Collections.Generic;

namespace ShopPortable.model
{
    public class Product
    {
        public const int VISIBILITY_NOT_VISIBLE = 1;
        public const int VISIBILITY_IN_CATALOG = 2;
        public const int VISIBILITY_IN_SEARCH = 3;
        public const int VISIBILITY_BOTH = 4;
        public const int STATUS_DISABLED = 2;
        public const int STATUS_ENABLED = 1;

        public long id { get; set; } = 1;
        public String sku { get; set; } = "product_dynamic_1";
        public String name { get; set; } = "Simple Product 1";
        public long attribute_set_id { get; set; } = 4;
        public double price { get; set; } = 0.0d;
        public int status { get; set; } = 1;
        public int visibility { get; set; } = 4;
        public String type_id { get; set; } = "simple";
        public String created_at { get; set; } = "2017-05-03 03:46:13";
        public String updated_at { get; set; } = "2017-05-03 03:46:13";
        public double weight { get; set; } = 1;
        public List<MagentoAttribute> extension_attributes { get; set; } = new List<MagentoAttribute>();
        public dynamic product_links { get; set; }
        public List<TierPrices> tier_prices { get; set; } = new List<TierPrices>();
        public List<MagentoAttribute> custom_attributes { get; set; } = new List<MagentoAttribute>();

    }
}
