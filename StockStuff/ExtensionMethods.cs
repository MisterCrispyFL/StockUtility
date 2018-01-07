namespace StockStuff
{
    using System;

    public static class ExtensionMethods
    {
        public static decimal ToCurrency(this decimal originalDecimal)
        {
            return Math.Round(originalDecimal, 2, MidpointRounding.AwayFromZero);
        }
    }
}