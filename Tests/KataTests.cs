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

        [Fact]
        public void Scan_MultipleDifferentItems_TotalIsCorrect()
        {
            var checkout = new KataCheckout();
            checkout.Scan("A99");
            checkout.Scan("B15");
            checkout.Scan("C40");

            var checkoutTotal = checkout.Total();

            Assert.Equal(1.40m, checkoutTotal);
        }
    }
}