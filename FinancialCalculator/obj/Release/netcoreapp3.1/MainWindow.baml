   M S B A M L   `   `   `  ���� N  JFinancialCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FinancialCalculatorFinancialCalculator  $    FinancialCalculator.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:FinancialCalculator       � Title$  
MainWindow��$	��450��$	��800��.��� .+��� -    ��Name$ 
lbExpenses��$��400,10,10,110q�   colExpenses#���   ���� .R��  � ColumnDefinitions ��  z� SharedSizeGroup$
 Name���� $ Value��.+��� $��2q�$��0������ *Name+�� $��2q�$��1������ *Value+�� -    ��Name$ inputExpenseName��$
��Left=�$��
10,130,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -   $ inputExpenseValue��$
��Left=�$��170,130,0,0q�$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ btnAddExpense��$��Add Expense��$
��Left=�$��
10,153,0,0q�$	��Top=�$��90���� $��Name:��$
��Left=�$��
10,105,0,0q�$	��Top=��� $��Amount:��$
��Left=�$��170,104,0,0q�$	��Top=��� -   $ btnRemoveExpense��$��Remove Expense��$
��Left=�$��400,369,0,0q�$	��Top=�$	��100���� -   $ inputIncome��$
��Left=�$��	10,45,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��Gross Income:��$
��Left=�$��	10,20,0,0q�$	��Top=��� -   $ btnSetIncome��$��
Set Income��$
��Left=�$��	10,68,0,0q�$	��Top=�$��90���� -    ��Name$ txtGrossIncomeValue��$�� ��$
��Left=�$��
100,20,0,0q�$	��Top=��� $��Net Income:��$
��Left=�$��
10,338,0,0q�$	��Top=��� -	   $ txtNetIncomeValue��$�� ��$
��Left=�$��
95,338,0,0q�$	��Top=��� -
   $ btnSaveData��$��
Save Input��$
��Left=�$��
10,369,0,0q�$	��Top=�$��90���� $��Total Expenses:��$
��Left=�$��400,338,0,0q�$	��Top=��� -   $ txtTotalExpensesValue��$�� ��$
��Left=�$��499,338,0,0q�$	��Top=�