using FinancialCalculator.Classes;
using System.Collections.Generic;
using System.Windows;

namespace FinancialCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SAVE_DATA_PATH = @"C:\Users\Connor\source\repos\FinancialCalculator\SaveData\SaveData.csv";
        private decimal iIncome { get; set; }
        private List<Expense> colExpenses { get; set; }

        /// <summary>
        /// MainWindow
        /// </summary>
        public MainWindow()
        {
            iIncome = Calculator.iIncome;
            colExpenses = Calculator.colExpenses;
            Resources["colExpenses"] = colExpenses;
            InitializeComponent();
            LoadData();
            CalculateNetIncome();
            CalculateTotalExpenses();
        }

        /// <summary>
        /// Handles the add expense button click
        /// </summary>
        private void btnAddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputExpenseName.Text) && !string.IsNullOrWhiteSpace(inputExpenseValue.Text))
            {
                string szExpenseValue = Expense.PrepareExpenseValue(inputExpenseValue.Text);

                Calculator.AddExpense(inputExpenseName.Text, szExpenseValue);
                inputExpenseName.Clear();
                inputExpenseValue.Clear();
                lbExpenses.Items.Refresh();
                CalculateNetIncome();
                CalculateTotalExpenses();
            }
        }

        /// <summary>
        ///  Handles the remove expense button click
        /// </summary>
        private void btnRemoveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (Calculator.colExpenses.Count > 0)
            {
                Calculator.RemoveExpense(lbExpenses.SelectedItem as Expense);
                lbExpenses.Items.Refresh();
                CalculateNetIncome();
                CalculateTotalExpenses();
            }
        }

        /// <summary>
        /// Handles the set income button click
        /// </summary>
        private void btnSetIncome_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputIncome.Text))
            {
                Calculator.iIncome = decimal.Parse(inputIncome.Text.Replace(" ", ""));
                txtGrossIncomeValue.Content = "$" + Calculator.iIncome.ToString();
                inputIncome.Clear();
                CalculateNetIncome();
            }
        }

        /// <summary>
        /// Writes input to csv file
        /// </summary>
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            Calculator.SaveData(SAVE_DATA_PATH);
        }

        /// <summary>
        /// Reads input from csv file
        /// </summary>
        private void LoadData()
        {
            Calculator.LoadData(SAVE_DATA_PATH);
            txtGrossIncomeValue.Content = "$" + Calculator.iIncome;
        }

        /// <summary>
        /// Calculates the the net income value and updates the UI
        /// </summary>
        private void CalculateNetIncome()
        {
            txtNetIncomeValue.Content = "$" + Calculator.CalculateNetIncome().ToString();
        }

        /// <summary>
        /// Calculates the total expenses value and updates the UI
        /// </summary>
        private void CalculateTotalExpenses()
        {
            txtTotalExpensesValue.Content = "$" + Calculator.SumExpenses().ToString();
        }
    }
}
