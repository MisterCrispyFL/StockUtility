namespace StockUtilities
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using StockStuff;

    public partial class MainWindow
    {
        private void Profit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateProfits();
        }

        private void CalculateProfits()
        {
            if (!CanCalculateProfit()) return;

            var calculator = new StockCalculator
            {
                CurrentPrice = Convert.ToDecimal(CurrentPrice.Text),
                NumberOfShares = Convert.ToInt32(NumberOfSharesOwned.Text),
                OriginalPrice = Convert.ToDecimal(PricePaid.Text),
                BrokerageFees = Convert.ToDecimal(BrokerageFee.Text)
            };

            var result = calculator.CalculateProfit();

            LblProfit.Content = $"Total Profit: ${result.TotalProfit:.##}{Environment.NewLine}Profit Per Share: ${result.ProfitPerShare:.##}";

        }

        private bool CanCalculateProfit()
        {
            //TODO: I hate this but it works. Refactor later.

            if (PricePaid == null ||
                CurrentPrice == null ||
                NumberOfSharesOwned == null ||
                BrokerageFee == null) return false;
            
            if (string.IsNullOrWhiteSpace(PricePaid.Text) ||
                string.IsNullOrWhiteSpace(CurrentPrice.Text) ||
                string.IsNullOrWhiteSpace(NumberOfSharesOwned.Text) ||
                string.IsNullOrWhiteSpace(BrokerageFee.Text)) return false;

            decimal pricePaid = decimal.TryParse(PricePaid.Text, out pricePaid) ? pricePaid : 0;
            decimal currentPrice = decimal.TryParse(CurrentPrice.Text, out currentPrice) ? currentPrice : 0;
            decimal numberOfShares = decimal.TryParse(NumberOfSharesOwned.Text, out numberOfShares) ? numberOfShares : 0;
            decimal brokerageFee = decimal.TryParse(BrokerageFee.Text, out brokerageFee) ? brokerageFee : 0;

            return pricePaid > 0 &&
                   currentPrice > 0 &&
                   numberOfShares > 0 &&
                   brokerageFee > 0;
        }
    }
}
