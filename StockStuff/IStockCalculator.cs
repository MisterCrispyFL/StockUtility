namespace StockStuff
{
    public interface IStockCalculator
    {
        decimal OriginalPrice { get; set; }
        decimal CurrentPrice { get; set; }
        int NumberOfShares { get; set; }
        decimal BrokerageFees { get; set; }
        decimal CalculateBreakEvenPrice();
        IProfitObject CalculateProfit();
    }
}