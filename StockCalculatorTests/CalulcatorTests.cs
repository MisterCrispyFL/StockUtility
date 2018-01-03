namespace StockCalculatorTests
{
    using System;
    using StockStuff;
    using Xunit;

    public class CalulcatorTests
    {
        [Theory]
        [InlineData(29.925, 6.95, 20, 30.62)]
        [InlineData(1.83, 9.95, 100, 2.03)]
        public void CalculateBreakEvenPrice_ReturnsProperValue(decimal originalPrice, decimal fee, int numberOfShares, decimal expected)
        {
            var factory = new StockCalculator
            {
                OriginalPrice = originalPrice,
                BrokerageFees = fee,
                NumberOfShares = numberOfShares
            };

            var result = factory.CalculateBreakEvenPrice();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(29.925, 67.23, 6.95, 20, 732.20, 36.61)]
        [InlineData(1.83, 1.7501, 9.95, 100, -27.89, -0.28)]
        public void CalculateProfit_ReturnsProperValue(decimal originalPrice, decimal currentPrice, decimal fee, int numberOfShares,
            decimal expectedTotal, decimal expetedPerShare)
        {
            var factory = new StockCalculator
            {
                CurrentPrice = currentPrice,
                NumberOfShares = numberOfShares,
                BrokerageFees = fee,
                OriginalPrice = originalPrice
            };

            var result = factory.CalculateProfit();

            Assert.Equal(expectedTotal, result.TotalProfit);
            Assert.Equal(expetedPerShare, result.ProfitPerShare);
        }

        //[Fact]
        //public void CalculateBreakEven_WithImproperData_ThrowsException()
        //{
        //    var factory = new StockCalculator();

        //    Exception ex = Assert.Throws<CalculatorException>(() => factory.CalculateBreakEvenPrice());

        //    Assert.Equal("Required Data Not Provided.", ex.Message);
        //}

        //[Fact]
        //public void CalculateProfit_WithImproperData_ThrowsException()
        //{
        //    var factory = new StockCalculator();

        //    Exception ex = Assert.Throws<CalculatorException>(() => factory.CalculateProfit());

        //    Assert.Equal("Required Data Not Provided.", ex.Message);
        //}
    }
}
