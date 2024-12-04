using System;

namespace FinancialCalculator.Classes
{
    /// <summary>
    /// Expense
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// The expense name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The expense value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The expense type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// GetValueAsDecimal
        /// </summary>
        public decimal GetValueAsDecimal()
        {
            return decimal.Parse(Value.Replace("$", ""));
        }

        /// <summary>
        /// Cleans an expense value
        /// </summary>
        /// <param name="expenseValue">The expense value.</param>
        public static string PrepareExpenseValue(string expenseValue)
        {
            if (expenseValue.Contains('.'))
            {
                string[] colExpenseValueParts = expenseValue.Split('.');

                // Throw if we have more than one period in the string
                if (colExpenseValueParts.Length != 2) throw new Exception("Invalid expense 'Amount' provided.");
            }
            else
            {
                // Add a decimal place and zeros if there are none
                expenseValue += ".00";
            }

            // Add a dollar sign
            expenseValue = "$" + expenseValue;

            // Remove whitespace and return
            return expenseValue.Replace(" ", "");
        }
    }
}
