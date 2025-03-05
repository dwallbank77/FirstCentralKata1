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

        [Fact]
        public void Scan_OfferAppliedForA99_TotalIsCorrect()
        {
            var checkout = new KataCheckout();
            checkout.Scan("A99");
            checkout.Scan("A99");
            checkout.Scan("A99");

            var checkoutTotal = checkout.Total();

            Assert.Equal(1.30m, checkoutTotal);
        }

        [Fact]
        public void Scan_OfferAppliedForB15_TotalIsCorrect()
        {
            var checkout = new KataCheckout();
            checkout.Scan("B15");
            checkout.Scan("B15");

            var checkoutTotal = checkout.Total();

            Assert.Equal(0.45m, checkoutTotal);
        }

        [Fact]
        public void Scan_OfferAndSingleItems_TotalIsCorrect()
        {
            var checkout = new KataCheckout();
            checkout.Scan("A99");
            checkout.Scan("A99");
            checkout.Scan("A99"); // 1.30 (offer applied)
            checkout.Scan("B15");
            checkout.Scan("B15"); // 0.45 (offer applied)
            checkout.Scan("B15"); // 0.30 (no offer applied)

            var checkoutTotal = checkout.Total();

            Assert.Equal(2.05m, checkoutTotal);
        }
    }
}