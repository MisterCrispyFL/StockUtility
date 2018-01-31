using System.Windows;

namespace StockUtilities
    {
    using System;
    using System.Windows.Controls;
    using StockStuff;

    public partial class MainWindow
        {
        private DividendPeriod DividendCalcPeriod { get; set; } = DividendPeriod.Yearly;

        private void DivCalc_TextChanged(object sender, TextChangedEventArgs e)
            {
            CalculateDividendYield();
            }

        private void CalculateDividendYield()
            {
            if (!CanCalculateYield()) return;

            var calculate = new DividendCalculator
                {
                StockPrice = Convert.ToDecimal(DivStockPrice.Text),
                NumberOfShares = Convert.ToInt32(DivNumberOfSharesOwned.Text),
                DividendPercentage = Convert.ToDecimal(DivPercent.Text)
                };

            var result = calculate.CalculateDividendYield(DividendCalcPeriod);

            LblDivYield.Content = $"Total Yield: ${result:.##}";
            }

        private bool CanCalculateYield()
            {
            if (DivStockPrice == null ||
                DivPercent == null ||
                DivNumberOfSharesOwned == null) return false;

            if (string.IsNullOrWhiteSpace(DivStockPrice.Text) ||
                string.IsNullOrWhiteSpace(DivNumberOfSharesOwned.Text) ||
                string.IsNullOrWhiteSpace(DivPercent.Text)) return false;

            decimal stockPrice = decimal.TryParse(DivStockPrice.Text, out stockPrice) ? stockPrice : 0.00M;
            int numberOfShares = int.TryParse(DivNumberOfSharesOwned.Text, out numberOfShares) ? numberOfShares : 0;
            decimal divPercent = decimal.TryParse(DivPercent.Text, out divPercent) ? divPercent : 0.00M;

            return stockPrice > 0 &&
                numberOfShares > 0 &&
                   divPercent > 0;
            }

        private void HandleDivCalcCheck(object sender, RoutedEventArgs e)
            {
            if (!(sender is RadioButton rb)) return;

            switch (rb.Name)
                {
                case "DivRbMonthly":
                    DividendCalcPeriod = DividendPeriod.Monthly;
                    CalculateDividendYield();
                    break;
                case "DivRbQuarterly":
                    DividendCalcPeriod = DividendPeriod.Quarterly;
                    CalculateDividendYield();
                    break;
                case "DivRbYearly":
                    DividendCalcPeriod = DividendPeriod.Yearly;
                    CalculateDividendYield();
                    break;
                default:
                    return;
                }

            CalculateDividendYield();
            }
        }
    }
