using System.Collections.Generic;
using System.IO;
using System.Text;
using FinancialCalculator.Classes;

namespace FinancialCalculator
{
    public static class Calculator
    {
        public static decimal iIncome;
        public static List<Expense> colExpenses = new List<Expense>();

        /// <summary>
        /// Adds an expense to the expenses list box
        /// </summary>
        public static void AddExpense(string expenseName, string expenseValue)
        {
            Expense oNewExpense = new Expense() { Name = expenseName, Value = expenseValue };

            if (!FindExpense(oNewExpense))
            {
                colExpenses.Add(oNewExpense);
            }

        }

        /// <summary>
        /// Removes an expense from the expenses list box
        /// </summary>
        public static void RemoveExpense(Expense selectedExpense)
        {
            colExpenses.Remove(selectedExpense);
        }

        /// <summary>
        /// Calculates the the net income value
        /// </summary>
        public static decimal CalculateNetIncome()
        {
            return iIncome - SumExpenses();
        }

        /// <summary>
        /// Writes input to csv file
        /// </summary>
        /// <param name="saveDataPath">The save data path.</param>
        public static void SaveData(string saveDataPath)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(iIncome.ToString());

            foreach (Expense oExpense in colExpenses)
            {
                sb.Append("," + oExpense.Name + "," + oExpense.Value);
            }

            File.WriteAllText(saveDataPath, sb.ToString());
        }

        /// <summary>
        /// Readys input from csv file
        /// </summary>
        /// <param name="saveDataPath">The save data path.</param>
        public static void LoadData(string saveDataPath)
        {
            string szData = File.ReadAllText(saveDataPath);
            string[] coldata = szData.Split(",");
            int index = 1;

            iIncome = decimal.Parse(coldata[0]);

            while (index < coldata.Length)
            {
                colExpenses.Add(new Expense
                {
                    Name = coldata[index],
                    Value = coldata[index + 1]
                });
                index = index + 2;
            }
        }

        /// <summary>
        /// Sums all expenses in colExpenses
        /// </summary>
        public static decimal SumExpenses()
        {
            decimal total = 0;
            foreach (Expense oExpense in colExpenses)
            {
                total = total + oExpense.GetValueAsDecimal();
            }
            return total;
        }

        /// <summary>
        /// Searches colExpenses for a given expense
        /// </summary>
        private static bool FindExpense(Expense expenseToFind)
        {
            foreach (Expense oExpense in colExpenses)
            {
                if (oExpense.Name == expenseToFind.Name) return true;
            }
            return false;
        }
    }
}
