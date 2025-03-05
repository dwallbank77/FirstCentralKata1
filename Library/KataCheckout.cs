namespace Kata.Library
{
    public class KataCheckout
    {
        private readonly Dictionary<string, decimal> _prices = new()
        {
            { "A99", 0.50m },
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
            decimal total = 0m;

            var sku = _scannedItems.FirstOrDefault().ToString();

            total = _prices[sku];

            return total;
        }
    }
}
