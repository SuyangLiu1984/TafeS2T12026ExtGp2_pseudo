using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private double CalculateMonthlyRepayment(
				double principal,
				double monthlyInterestRate,
				int totalMonths)
		{
			double power = Math.Pow(1 + monthlyInterestRate, totalMonths);

			double numerator = principal * (monthlyInterestRate * power);

			double denominator = power - 1;

			double repayment = numerator / denominator;

			return repayment;
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double principal = double.Parse(principalInput.Text);
				int years = string.IsNullOrWhiteSpace(yearsInput.Text)
					? 0
					: int.Parse(yearsInput.Text);

				int months = string.IsNullOrWhiteSpace(monthsInput.Text)
					? 0
					: int.Parse(monthsInput.Text);
				double annualInterestRate = double.Parse(annualInterestInput.Text);

				if (principal <= 0 || years < 0 || months < 0 || annualInterestRate < 0)
				{ throw new Exception(); }

				if (years == 0 && months ==0)
				{  throw new Exception(); }

				double monthlyInterestRate = annualInterestRate / 100 / 12;

				int totalMonths = years * 12 + months;

				double monthlyRepayment = CalculateMonthlyRepayment(
					principal,
					monthlyInterestRate,
					totalMonths);

				monthlyRepaymentOutput.Text = monthlyRepayment.ToString("F2");

				monthlyInterestOutput.Text = (monthlyInterestRate * 100).ToString("F2") + "%";
			}

			catch
			{
				ContentDialog dialog = new ContentDialog
				{
					Title = "Invalid Input",
					Content = "Please enter valid numbers.",
					CloseButtonText = "OK"
				};

				await dialog.ShowAsync();
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
