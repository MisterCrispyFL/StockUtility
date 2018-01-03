namespace StockStuff
{
    public interface IProfitObject
    {
        decimal TotalProfit { get; set; }
        decimal ProfitPerShare { get; set; }
    }
}