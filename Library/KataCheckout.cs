namespace Kata.Library
{
    public class KataCheckout
    {
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
            var groupedItems = _scannedItems.GroupBy(sku => sku);
            decimal total = 0m;

            foreach (var group in groupedItems)
            {
                string sku = group.Key;
                int quantity = group.Count();

                total += quantity * _prices[sku];
            }

                return total;
        }
    }
}
