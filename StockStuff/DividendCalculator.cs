using System;

namespace StockStuff
{
    public class DividendCalculator : IDividendCalc
    {
        public decimal StockPrice { get; set; }
        public decimal DividendPercentage { get; set; }
        public int NumberOfShares { get; set; }
        public decimal DividendYield { get; set; }
        public decimal CalculateDividendYield()
        {
            var rawCalculatedAmount = ((DividendPercentage / 100) * StockPrice) * NumberOfShares;
            return rawCalculatedAmount.ToCurrency();
        }

        public int CalculateNeededShares()
        {
            var numberOfShares = (DividendYield/(DividendPercentage/100))/StockPrice;

            var roundedNumberOfShares = Convert.ToInt32(numberOfShares);

            return roundedNumberOfShares;
        }
    }
}
