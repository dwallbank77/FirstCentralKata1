namespace Kata.Library
{
    public class KataCheckout
    {
        private readonly Dictionary<string, (int Quantity, decimal OfferPrice)> _offers = new()
        {
            { "A99", (3, 1.30m) },
            { "B15", (2, 0.45m) }
        };

        private readonly Dictionary<string, decimal> _prices = new()
        {
            { "A99", 0.50m },
            { "B15", 0.30m },
            { "C40", 0.60m }
        };

        private readonly List<string> _scannedItems = new();

        public void Scan(string skuItem)
        {
            if (_prices.ContainsKey(skuItem))
            {
                _scannedItems.Add(skuItem);
            }
        }

        public decimal Total()
        {
            var productGroupedItems = _scannedItems.GroupBy(sku => sku);
            decimal total = 0m;

            foreach (var productItem in productGroupedItems)
            {
                string sku = productItem.Key;
                int quantity = productItem.Count();

                if (_offers.ContainsKey(sku))
                {
                    var (offerQuantity, offerPrice) = _offers[sku];
                    int offerSets = quantity / offerQuantity;
                    int remainder = quantity % offerQuantity;

                    total += (offerSets * offerPrice) + (remainder * _prices[sku]);
                    // if has an offer & total
                }
                else
                {
                    total += quantity * _prices[sku];
                    // if no offer & total
                }
            }

            return total;
        }
    }
}
