using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ShopPortable.model
{
    public class MagentoAttribute
    {
        public string attribute_code { get; set; } = "description";
        public dynamic value { get; set; }

       // public List<string> value { get; set; } = new List<string>();
       
        public MagentoAttribute()
        {
        }

    }
}
