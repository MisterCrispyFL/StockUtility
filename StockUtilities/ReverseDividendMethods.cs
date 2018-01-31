using System.Windows;

namespace StockUtilities
    {
    using System;
    using System.Windows.Controls;
    using StockStuff;

    public partial class MainWindow
        {
        private DividendPeriod ReverseDividendCalcPeriod { get; set; } = DividendPeriod.Yearly;

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
            var result = calculator.CalculateNeededShares(ReverseDividendCalcPeriod);

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

        private void HandleRevDivCalcCheck(object sender, RoutedEventArgs e)
            {
            if (!(sender is RadioButton rb)) return;

            switch (rb.Name)
                {
                case "RevDivRbMonthly":
                    ReverseDividendCalcPeriod = DividendPeriod.Monthly;
                    ReverseCalculateDividend();
                    break;
                case "RevDivRbQuarterly":
                    ReverseDividendCalcPeriod = DividendPeriod.Quarterly;
                    ReverseCalculateDividend();
                    break;
                case "RevDivRbYearly":
                    ReverseDividendCalcPeriod = DividendPeriod.Yearly;
                    ReverseCalculateDividend();
                    break;
                default:
                    return;
                }

            ReverseCalculateDividend();
            }
        }

    }
