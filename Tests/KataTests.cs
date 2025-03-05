using Kata.Library;

namespace Kata.Tests
{
    public class KataTests
    {
        [Fact]
        public void ScanItem_Single_TotalIsCorrect()
        {
            var checkout = new KataCheckout();
            checkout.Scan("A99");

            var checkoutTotal = checkout.Total();

            Assert.Equal(0.50m, checkoutTotal);
        }
    }
}