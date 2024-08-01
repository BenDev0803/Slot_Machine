using System;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
            int[,] slotNumbers = new int[Constants.ROWS, Constants.COLUMNS]; // define the exact number of rows and columns
            // declare number of matching rows/columns that later will change depending on the progression of the game

            int numberOfMatches = 0;
            bool playAgain = true;

            while (playAgain) // while loop is used for repeating a block of code until the user blocks it
            {
                
                
                
                numberOfMatches = 0; // reset number of matches

                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------

                slotNumbers = Logic.PopulateGrid(slotNumbers);

                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(Constants.MIN, Constants.MAX + 1);
                        slotNumbers[col, row] = 1;
                        if (col == 0)
                        {
                            slotNumbers[col, row] = 2;
                        }
                        if(col == 1)
                        {
                            slotNumbers[col, row] = 3;
                        }
                    }

                }
                //-----------------------------------------------------

                UI_Design.DisplayArrayInRowsAndColumns(slotNumbers);

                //Console.WriteLine();

                //block that decides if there is a row win or not
                //if gamemode ....
                if (Constants.ROWS_CHAR == userChoiceChar)
                {
                    numberOfMatches = Logic.FindNumberOfMatchingRows(slotNumbers);

                }
                

                cashBox = cashBox + Logic.CalcRowsWinnings(numberOfMatches);

                //call ui method for the user info PrintResult(numberofmatches);

                UI_Design.OutputWinLoseRows(numberOfMatches);
                if (UI_Design.OutputWinLoseRows(numberOfMatches)==0)
                {
                    break;
                }
                UI_Design.PrintTotalAmountMoney(totalAmountMoney);

                

                if (Constants.COLUMNS_CHAR == userChoiceChar)
                {
                    numberOfMatches =  Logic.FindNumberOfMatchingColumns(slotNumbers);
                }

                cashBox = cashBox + Logic.CalcColumnsWinning(numberOfMatches);
                //call ui method for the user info PrintResult(numberofmatches);
                UI_Design.OutputWinLoseColumns(numberOfMatches);
                UI_Design.PrintTotalAmountMoney(totalAmountMoney);
                playAgain = Logic.FinalLogic(cashBox);

                Console.Clear();

            }
        }
    }
}
