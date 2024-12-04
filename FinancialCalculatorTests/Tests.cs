using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialCalculator.Classes;
using System.IO;

namespace FinancialCalculator.Tests
{
    /// <summary>
    /// CalculatorTests
    /// </summary>
    [TestClass]
    public class Tests
    {
        private const string NAME = "TestExpense";
        private const string VALUE = "10.00";

        /// <summary>
        /// Resets Calculator property values
        /// </summary>
        private void TestCleanup()
        {
            Calculator.iIncome = 0;
            Calculator.colExpenses.Clear();
        }

        /// <summary>
        /// AddExpenseTests
        /// </summary>
        [TestMethod]
        public void AddExpenseTest()
        {
            // Arrange / Act
            Calculator.AddExpense(NAME, VALUE);

            // Assert
            Assert.AreEqual(NAME, Calculator.colExpenses[0].Name);
            Assert.AreEqual(VALUE, Calculator.colExpenses[0].Value);

            // Cleanup
            TestCleanup();
        }

        /// <summary>
        /// RemoveExpenseTests
        /// </summary>
        [TestMethod]
        public void RemoveExpenseTest()
        {
            // Arrange
            Expense oExpense = new Expense
            {
                Name = NAME,
                Value = VALUE
            };
            Calculator.colExpenses.Add(oExpense);

            Assert.AreEqual(1, Calculator.colExpenses.Count);

            // Act
            Calculator.RemoveExpense(oExpense);

            // Assert
            Assert.AreEqual(0, Calculator.colExpenses.Count);
        }

        /// <summary>
        /// CalculatenetIncomeTests
        /// </summary>
        [TestMethod]
        public void CalculateNetIncomeTest()
        {
            // Arrange
            Calculator.iIncome = 1000.00m;
            Expense oExpense = new Expense
            {
                Name = NAME,
                Value = VALUE
            };
            Calculator.colExpenses.Add(oExpense);

            // Act
            decimal dNetIncome = Calculator.CalculateNetIncome();

            // Assert
            Assert.AreEqual(990.00m, dNetIncome);

            // Cleanup
            TestCleanup();
        }

        /// <summary>
        /// SaveDataTests
        /// </summary>
        [TestMethod]
        public void SaveDataTest()
        {
            // Arrange
            string szSaveDataPath = @"C:\Users\Connor\source\repos\FinancialCalculator\SaveData\SaveDataTest.csv";
            Calculator.iIncome = 1000.00m;
            Expense oExpense = new Expense
            {
                Name = NAME,
                Value = VALUE
            };
            Calculator.colExpenses.Add(oExpense);

            // Act
            Calculator.SaveData(szSaveDataPath);

            // Assert
            Assert.AreEqual("1000.00,TestExpense,10.00", File.ReadAllText(szSaveDataPath));

            // Cleanup
            TestCleanup();
        }

        /// <summary>
        /// LoadDataTest
        /// </summary>
        [TestMethod]
        public void LoadDataTest()
        {
            // Arrange
            string szSaveDataPath = @"C:\Users\Connor\source\repos\FinancialCalculator\SaveData\SaveDataTest.csv";

            // Act
            Calculator.LoadData(szSaveDataPath);

            // Assert
            Assert.AreEqual(1000.00m, Calculator.iIncome);
            Assert.AreEqual("TestExpense", Calculator.colExpenses[0].Name);
            Assert.AreEqual("10.00", Calculator.colExpenses[0].Value);

            // Cleanup
            TestCleanup();
        }

        /// <summary>
        /// SumExpensesTest
        /// </summary>
        [TestMethod]
        public void SumExpensesTest()
        {
            // Arrange
            Expense oTestExpense1 = new Expense() { Name = "TestExpense1", Value = "10.00" };
            Expense oTestExpense2 = new Expense() { Name = "TestExpense2", Value = "15.00" };
            Calculator.colExpenses.Add(oTestExpense1);
            Calculator.colExpenses.Add(oTestExpense2);

            // Act
            decimal dExpectedResult = Calculator.SumExpenses();

            // Assert
            Assert.AreEqual(25.00m, dExpectedResult);

            // Cleanup
            TestCleanup();
        }

        /// <summary>
        /// PrepareExpenseValueTest
        /// </summary>
        [TestMethod]
        public void PrepareExpenseValueTest()
        {
            // Arrange
            string szExpenseValue = "20";

            // Act
            string szResult = Expense.PrepareExpenseValue(szExpenseValue);

            // Assert
            Assert.AreEqual("$20.00", szResult);
        }
    }
}