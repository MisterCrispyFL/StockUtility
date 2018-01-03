namespace StockStuff
{
    using System;

    public class StockCalculator : IStockCalculator
    {
        public decimal OriginalPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int NumberOfShares { get; set; }
        public decimal BrokerageFees { get; set; }

        public decimal CalculateBreakEvenPrice()
        {
            if (!CanCalculateBreakEven()) return 0.00M;
            var finalAmount = ((OriginalPrice * NumberOfShares) + (BrokerageFees * 2)) / NumberOfShares;
            
            return finalAmount > 0 ? Math.Round(finalAmount, 2, MidpointRounding.AwayFromZero) : 0.00M;
        }

        public IProfitObject CalculateProfit()
        {
            if (!CanCalculateProfit()) return new ProfitObject {TotalProfit = 0.00M, ProfitPerShare = 0.00M};

            var currentTotal = CurrentPrice * NumberOfShares;
            var originalTotal = OriginalPrice * NumberOfShares;
            var totalProfit = currentTotal - originalTotal - (BrokerageFees * 2);
            var profitPerShare = totalProfit / NumberOfShares;

            var profitObject = new ProfitObject
            {
                ProfitPerShare = Math.Round(profitPerShare, 2, MidpointRounding.AwayFromZero),
                TotalProfit = Math.Round(totalProfit, 2, MidpointRounding.AwayFromZero)
            };

            return profitObject;
        }

        private bool CanCalculateBreakEven()
        {
            return OriginalPrice > 0 &&
                   NumberOfShares > 0 &&
                   BrokerageFees > 0;
        }

        private bool CanCalculateProfit()
        {
            return OriginalPrice > 0 &&
                   CurrentPrice > 0 &&
                   NumberOfShares > 0 &&
                   BrokerageFees > 0;
        }
    }
}
