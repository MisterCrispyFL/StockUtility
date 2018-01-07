namespace StockUtilities
{
    using System;
    using System.Windows.Controls;
    using StockStuff;

    public partial class MainWindow
    {
        private void RevCalc_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReverseCalculateDividend();
        }

        private void ReverseCalculateDividend()
        {
            if (!CanReverseCalculate()) return;

            var calculator = new DividendCalculator
                             {
                                 StockPrice = Convert.ToDecimal(RevStockPrice.Text),
                                 DividendPercentage = Convert.ToDecimal(RevPercent.Text),
                                 DividendYield = Convert.ToDecimal(RevDesiredYield.Text)
                            };
            var result = calculator.CalculateNeededShares();

            LblRevSharedNeeded.Content = $"Shares Needed: {result}";
        }

        private bool CanReverseCalculate()
        {
            if (RevStockPrice == null ||
                RevPercent == null ||
                RevDesiredYield == null) return false;

            if (string.IsNullOrWhiteSpace(RevStockPrice.Text) || 
                string.IsNullOrWhiteSpace(RevPercent.Text) || 
                string.IsNullOrWhiteSpace(RevDesiredYield.Text)) return false;

            decimal stockPrice = decimal.TryParse(RevStockPrice.Text, out stockPrice) ? stockPrice : 0.00M;
            decimal divPercent = decimal.TryParse(RevPercent.Text, out divPercent) ? divPercent : 0.00M;
            decimal desiredYield = decimal.TryParse(RevDesiredYield.Text, out desiredYield) ? desiredYield : 0.00M;


            return stockPrice > 0 &&
                   desiredYield > 0 &&
                   divPercent > 0;
        }
    }
}
