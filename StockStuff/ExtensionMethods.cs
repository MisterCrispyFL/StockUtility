namespace StockStuff
    {
    using System;

    public static class ExtensionMethods
        {
        public static decimal ToCurrency(this decimal originalDecimal)
            {
            return Math.Round(originalDecimal, 2, MidpointRounding.AwayFromZero);
            }

        public static int ToInt(this DividendPeriod period)
            {
            switch (period)
                {
                case DividendPeriod.Monthly:
                    return 12;
                case DividendPeriod.Quarterly:
                    return 4;
                case DividendPeriod.Yearly:
                    return 1;
                default:
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }