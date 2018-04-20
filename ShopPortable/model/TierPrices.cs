using System;
namespace ShopPortable.model
{
    public class TierPrices
    {
        public long customer_group_id { get; set; } = 1;
        public long qty { get; set; } = 10000;
        public double value { get; set; } = 10;
        public TierPrices()
        {
        }
    }
}
