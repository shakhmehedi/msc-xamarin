using System;
using System.Collections.Generic;

namespace ShopPortable.model
{
    
    public class ProductAttribute
    {
        public bool is_wysiwyg_enabled { get; set; } = false;
        public bool is_html_allowed_on_front { get; set; } = false;
        public bool used_for_sort_by { get; set; } = true;
        public bool is_filterable { get; set; } = false;
        public bool is_filterable_in_search { get; set; } = false;
        public bool is_used_in_grid { get; set; } = false;
        public bool is_visible_in_grid { get; set; } = false;
        public bool is_filterable_in_grid { get; set; } = false;
        public int position { get; set; } = 0;
        public List<String> apply_to { get; set; } = new List<string>();
        public String is_searchable { get; set; } = "1";
        public String is_visible_in_advanced_search { get; set; } = "1";
        public String is_comparable { get; set; } = "0";
        public String is_used_for_promo_rules { get; set; } = "0";
        public String is_visible_on_front { get; set; } = "0";
        public String used_in_product_listing { get; set; } = "1";
        public bool is_visible { get; set; } = true;
        public String scope { get; set; } = "store";
        public long attribute_id { get; set; } = 73;
        public String attribute_code { get; set; } = "name";
        public String frontend_input { get; set; } = "text";
        public String entity_type_id { get; set; } = "4";
        public bool is_required { get; set; } = true;
        public List<String> options { get; set; } = new List<string>();
        public bool is_user_defined { get; set; } = false;
        public String default_frontend_label { get; set; } = "Product Name";
        public String frontend_labels { get; set; } = null;
        public String backend_type { get; set; } = "varchar";
        public String is_unique { get; set; } = "0";
        public String frontend_class { get; set; } = "validate-length maximum-length-255";
        public List<String> validation_rules { get; set; } = new List<string>();



    }
}

