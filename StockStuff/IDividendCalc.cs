namespace StockStuff
{
    public interface IDividendCalc
    {
        decimal StockPrice { get; set; }
        decimal DividendPercentage { get; set; }
        int NumberOfShares { get; set; }
        decimal DividendYield { get; set; }
        decimal CalculateDividendYield();
        int CalculateNeededShares();

    }
}