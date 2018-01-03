using System;

namespace StockUtilities
{
    using System.Diagnostics;
    using System.Windows.Controls;
    using StockStuff;

    public partial class MainWindow
    {
        private void BreakEven_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateBreakEven();
        }

        private bool CanCalculate()
        {
            if (StockPrice == null ||
                NumberOfShares == null ||
                TradeFee == null) return false;

            if (string.IsNullOrWhiteSpace(StockPrice.Text) ||
                string.IsNullOrWhiteSpace(NumberOfShares.Text) ||
                string.IsNullOrWhiteSpace(TradeFee.Text)) return false;

            decimal stockPrice = decimal.TryParse(StockPrice.Text, out stockPrice) ? stockPrice : 0;
            decimal numberOfShares = decimal.TryParse(NumberOfShares.Text, out numberOfShares) ? numberOfShares : 0;
            decimal tradeFee = decimal.TryParse(TradeFee.Text, out tradeFee) ? tradeFee : 0;

            return stockPrice > 0 &&
                   numberOfShares > 0 &&
                   tradeFee > 0;

        }

        private void CalculateBreakEven()
        {
            if (!CanCalculate()) return;

            try
            {
                var calculator = new StockCalculator
                {
                    OriginalPrice = Convert.ToDecimal(StockPrice.Text),
                    NumberOfShares = Convert.ToInt32(NumberOfShares.Text),
                    BrokerageFees = Convert.ToDecimal(TradeFee.Text)
                };

                var finalAmount = calculator.CalculateBreakEvenPrice();

                LblBreakEvenPrice.Content = $"Break Even Price: ${finalAmount}";
            }
            catch (Exception exception)
            {
                //Do Something
            }
        }
    }
}
