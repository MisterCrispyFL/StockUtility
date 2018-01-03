namespace StockStuff
{
    public class ProfitObject : IProfitObject
    {
        public decimal TotalProfit { get; set; }
        public decimal ProfitPerShare { get; set; }
    }
}