using System;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ROWS = 3;
            const int COLUMNS = 3;
            //declare range of numbers that should be displayed randomly
            const int MAX = 9;
            const int MIN = 1;
            // declare bonus win for multiple matching rows/columns

            // declare characters that user should press for choosing rows, diagonals, columns, yes or no
            const char COLUMNS_CHAR = 'c';
            const char ROWS_CHAR = 'r';
            const char DIA_CHAR = 'd';
            const char YES_CHAR = 'y';
            const char NO_CHAR = 'n';

            // creates random number
            Random random = new Random();
            //game start initial statement
            UI_Design.PrintInitialStatement();
            //the user here inputs the amount of money that wants to bet
            int userBet = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            string youBet = "you bet " + userBet;
            UI_Design.PrintYouBet(youBet);
            int cashBox = userBet;
            string totalAmountMoney = "your total amount of money is " + cashBox;
            UI_Design.PrintTotalAmountMoney(totalAmountMoney);
            // game start second statement
            Char userChoiceChar = UI_Design.GetUserChoice();
            UI_Design.PrintuserChoiceText();
     
            // initialized array with the slot numbers
            int[,] slotNumbers = new int[ROWS, COLUMNS]; // define the exact number of rows and columns
            // declare number of matching rows/columns that later will change depending on the progression of the game

            int numberOfMatches = 0;
            bool winningMatchFound = true;
            bool winningMatchFoundLeft = true;
            bool winningMatchFoundRight = true;

            while (true) // while loop is used for repeating a block of code until the user blocks it
            {
                numberOfMatches = 0; // reset number of matches
                
                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------

                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(MIN, MAX + 1);
                        slotNumbers[col, row] = computerChoice;
                    }
                }
                //-----------------------------------------------------

                UI_Design.DisplayArrayInRowsAndColumns(slotNumbers);

                //block that decides if there is a row win or not
                //if gamemode ....
                if (ROWS_CHAR == userChoiceChar)
                {
                    Logic.FindNumberOfMatchingRows(slotNumbers);
                }

                cashBox = cashBox + Logic.CalcRowsWinnings(numberOfMatches);

                //call ui method for the user info PrintResult(numberofmatches);
                UI_Design.OutputWinLoseRows(numberOfMatches);

                UI_Design.PrintTotalAmountMoney(totalAmountMoney);


            }
        }
    }
}
